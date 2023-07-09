using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : Furniture
{
    public AudioClip audioClip;
    public override void Interact()
    {
        animator.SetBool("interact", true);
    }

    public override void Leave()
    {
        animator.SetBool("interact", false);
    }

    public override void TurnOff()
    {
        animator.SetBool("animate", false);
    }

    public override void TurnOn()
    {
        animator.SetBool("animate", true);
    }
}
