using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : Furniture
{
    public AudioClip audioClip;
    private int phases;
    private bool watering;

    public Sprite Phase1;
    public Sprite Phase2;

    public override void Interact()
    {
        phases++;
        watering = true;
        if(phases == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Phase1;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Phase2;
        }
    }

    public override void Leave()
    {
        watering = false;
    }

    public override void TurnOff()
    {
    }

    public override void TurnOn()
    {
        if(watering && phases >= 2)
        {
            deathManager.PlantDeath();
        }
    }
}
