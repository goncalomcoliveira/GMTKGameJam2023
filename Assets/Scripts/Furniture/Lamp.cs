using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : Furniture
{
    public override void TurnOff()
    {
        animator.SetBool("animate", false);
    }

    public override void TurnOn()
    {
        animator.SetBool("animate", true);
    }
}
