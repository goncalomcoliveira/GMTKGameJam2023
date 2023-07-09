using UnityEngine;

public class Action : Interaction
{
    public string name;
    public int minTime;
    public int maxTime;

    public override int Execute()
    {
        //Change animator
        if (furniture is object) furniture.Interact();

        int time = Random.Range(minTime, maxTime + 1);
        //Debug.Log("Executing action: " + name + " for " + time + " seconds");
        return time;
    }

    public override void Finish()
    {
        if (furniture is object) furniture.Leave();
    }

    public override bool Equals(object other)
    {
        return name.Equals(((Action)other).name);
    }
}
