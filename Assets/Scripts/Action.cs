using UnityEngine;

public class Action : Interaction
{
    public string name;
    public int minTime;
    public int maxTime;

    public override int Execute()
    {
        //Change animator

        int time = Random.Range(minTime, maxTime);
        Debug.Log("Executing action: " + name + " for " + time + " seconds");
        return time;
    }

    public override Position Move()
    {
        //Walk to coordinates

        return position;
    }
}
