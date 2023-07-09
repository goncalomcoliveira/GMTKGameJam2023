using System;
using UnityEngine;

[System.Serializable]
public class Warning : Interaction, IComparable
{
    public string name;
    public int time;
    public int priority;
    public int soundRadius;
    public int roomNumber;

    public override int Execute()
    {
        //Change animator

        Debug.Log("Interrupted by " + name + " for " + time + " seconds");
        return time;
    }

    public override void Finish()
    {
        furniture.Deactivate();
    }

    public int CompareTo(object obj)
    {
        return priority.CompareTo(((Warning) obj).priority);
    }
}
