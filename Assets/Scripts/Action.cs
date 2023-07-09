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
        return time;
    }

    public override void Finish()
    {

    }
}
