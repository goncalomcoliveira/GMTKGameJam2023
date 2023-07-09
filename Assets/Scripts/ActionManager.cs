using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public List<Action> initialActions;
    private static List<Action> avail = new List<Action>();

    public void Awake()
    {
        avail = initialActions;
    }

    public static Action GetRandomAction(List<Action> actions)
    {
        List<Action> result = new List<Action>();
        foreach(Action actionAvail in avail)
        {
            foreach(Action action in actions) {
                if (action.Equals(actionAvail)) result.Add(actionAvail);
            }
        }

        return result[Random.Range(0, result.Count)];
    }

    public static void AddAction(Action action)
    {
        avail.Add(action);
        Debug.Log("Added to pos: " + action.position);
    }
}
