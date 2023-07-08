using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string name;
    public Position position;
    public List<Action> actions = new List<Action>();
    public List<Warning> warningQueue = new List<Warning>();
    //public List<Skill> skills;
    public Room room;

    private Interaction executing;
    private bool busy = false;
    private int time = 0;
    private Interaction interrupted;

    private bool delete = true;

    // Start is called before the first frame update
    void Start()
    {
        /*position = new Pair(0,0);

        actions = new List<Action>
        {
            new Action
            {
                name = "A1",
                coordinates = new Pair(0,0),
                minTime = 5,
                maxTime = 10
            },
            new Action
            {
                name = "A2",
                coordinates = new Pair(0,0),
                minTime = 5,
                maxTime = 10
            },
            new Action
            {
                name = "A3",
                coordinates = new Pair(0,0),
                minTime = 5,
                maxTime = 10
            }
        };*/
    }

    // Update is called once per frame
    void Update()
    {
        if (executing is null)
        {
            //Execute();
        }
        else if (!busy)
        {
            if (position.Equals(executing.position))
            {
                busy = true;
                time = executing.Execute();
                StartCoroutine(wait());
            }
        }
    }

    IEnumerator wait()
    {
        while (--time > 0)
        {
            yield return new WaitForSeconds(1);
        }

        busy = false;
        executing = null;
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

        executing.Move();
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
        Pathfinding.Search(new Position(5, 1), new Position(15, 14), room);
    }
}