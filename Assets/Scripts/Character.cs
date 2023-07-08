using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string name;
    public List<Action> actions = new List<Action>();
    public List<Warning> warningQueue = new List<Warning>();
    //public List<Skill> skills;
    public Room room;
    public CharacterMovement movement;

    private Interaction executing;
    private bool busy = false;
    private int time = 0;
    private Interaction interrupted;

    private bool delete = true;

    // Start is called before the first frame update
    void Start()
    {
        room.Start();

        Test();

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
            Debug.Log(time);
            yield return new WaitForSeconds(1);
        }

        busy = false;
        executing = null;
        movement.local = false;
    }

    /*
    public void GenerateSkills()
    {

    }
    */

    public void Execute()
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

            executing = warningQueue[0];
            warningQueue.RemoveAt(0);
        }
        else if (interrupted is null)
        {
            int actionIndex = Random.Range(0, actions.Count);
            executing = actions[actionIndex];
        }
        else
        {
            executing = interrupted;
            interrupted = null;
        }

        executing.Move(movement.position, room, movement);
    }

    public void Interrupt(Warning warning)
    {
        StopAllCoroutines();
        busy = false;
        warningQueue.Add(warning);

        Execute();
    }

    public void Test()
    {
        actions = new List<Action>
        {
            new Action
            {
                name = "A1",
                position = new Position(15,14),
                minTime = 5,
                maxTime = 10
            },
            new Action
            {
                name = "A2",
                position = new Position(5,4),
                minTime = 5,
                maxTime = 10
            },
            new Action
            {
                name = "A3",
                position = new Position(2,12),
                minTime = 5,
                maxTime = 10
            }
        };
    }
}