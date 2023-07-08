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
        foreach(Action action in actions)
        {
            if (avail.Contains(action)) result.Add(action);
        }

        return result[Random.Range(0, result.Count - 1)];
    }

    public static void AddAction(Action action)
    {
        avail.Add(action);
    }
}
