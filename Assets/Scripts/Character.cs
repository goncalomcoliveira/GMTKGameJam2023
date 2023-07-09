using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string name;
    public Skill skill;

    public List<Action> actions = new List<Action>();
    public PriorityQueue<Warning> warningQueue = new PriorityQueue<Warning>();
    public CharacterMovement movement;

    [HideInInspector]
    public Room room;

    private Interaction executing;
    private bool busy = false;
    private int time = 0;
    private Interaction interrupted;

    // Start is called before the first frame update
    void Start()
    {
        room = GameObject.FindGameObjectsWithTag("room")[0].GetComponent<Room>();
        room.Start();

        movement.position = new Position(7, 10);
        movement.transform.position = room.GetVector(movement.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (executing is null)
        {
            if (actions.Count != 0) Execute();
        }
        else if (!busy && movement.local)
        {
            busy = true;
            time = executing.Execute();
            StartCoroutine(wait());
        }
    }

    public IEnumerator wait()
    {
        while (--time > 0)
        {
            yield return new WaitForSeconds(1);
        }

        executing.Finish();
        busy = false;
        executing = null;
        movement.local = false;       
    }

    private void Execute()
    {
        if (warningQueue.Count > 0)
        {
            if (executing is Action)
            {
                interrupted = executing;
            }
            else if (executing is Warning)
            {
                return;
            }

            executing = warningQueue.Dequeue();
        }
        else if (interrupted is null)
        {
            executing = ActionManager.GetRandomAction(actions);
        }
        else
        {
            executing = interrupted;
            interrupted = null;
        }

        executing.Move(movement.position, room, movement);
    }

    public bool Interrupt(Warning warning)
    {
        if (Notice(warning))
        {
            StopAllCoroutines();
            busy = false;

            warningQueue.Enqueue(warning);
            Execute();
            return false;
        }

        return true;
    }

    private bool Notice(Warning warning)
    {
        bool sound = (Mathf.Pow(warning.position.x - movement.position.x,2) + Mathf.Pow(warning.position.y - movement.position.y, 2)) <= Mathf.Pow(warning.soundRadius,2);
        bool sameRoom = room.GetRoom(movement.position.x, movement.position.y) == warning.roomNumber;

        bool linearVisionVertical = movement.position.y == warning.position.y;
        for(int i = movement.position.x; i != warning.position.x; i -= (int) ((movement.position.x - warning.position.x)/Mathf.Abs(movement.position.x - warning.position.x)))
        {
            if (!linearVisionVertical) break;
            linearVisionVertical = room.Matrix[i, movement.position.y] is not Wall;
        }

        bool linearVisionHorizontal = movement.position.x == warning.position.x;
        for (int i = movement.position.y; i != warning.position.y; i -= (int)((movement.position.y - warning.position.y) / Mathf.Abs(movement.position.y - warning.position.y)))
        {
            if (!linearVisionHorizontal) break;
            linearVisionHorizontal = room.Matrix[movement.position.x, i] is not Wall;
        }
        bool vision = sameRoom || linearVisionVertical || linearVisionHorizontal;

        return sound || vision;
    }
}