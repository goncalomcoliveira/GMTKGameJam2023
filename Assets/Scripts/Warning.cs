using UnityEngine;

public class Warning : Interaction
{
    public string name;
    public int time;

    public override int Execute()
    {
        //Change animator

        Debug.Log("Interrupted by " + name + " for " + time + " seconds");
        return time;
    }

    public override Position Move()
    {
        //Walk to coordinates

        return position;
    }
}
