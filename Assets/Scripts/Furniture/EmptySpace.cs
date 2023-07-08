using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySpace : Furniture
{
    public Sprite BuildSquare;
    public override void TurnOff()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = null;
    }

    public override void TurnOn()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = BuildSquare;
    }

    public void Click()
    {
    }
}
