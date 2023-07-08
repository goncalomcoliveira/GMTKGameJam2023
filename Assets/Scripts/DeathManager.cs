using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class DeathManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Environment(List<Quality> qualities)
    {
        foreach (Quality quality in qualities)
        {
            switch (quality)
            {
                case Quality.Distract:
                    break;
                case Quality.Electricity:
                    break;
                case Quality.Water:
                    break;
            }
        }
    }

    public static void EnvironmentRemove(List<Quality> qualities)
    {
        foreach (Quality quality in qualities)
        {
            switch (quality)
            {
                case Quality.Distract:
                    break;
                case Quality.Electricity:
                    break;
                case Quality.Water:
                    break;
            }
        }
    }
}
