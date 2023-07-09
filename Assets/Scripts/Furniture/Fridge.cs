using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : Furniture
{
    public Sprite open;
    public Sprite closed;
    public override void Interact()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = open;
    }

    public override void Leave()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = closed;
    }

    public override void TurnOff()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = open;
    }

    public override void TurnOn()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = closed;
    }
}
