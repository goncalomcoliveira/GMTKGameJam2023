using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : Furniture
{
    public AudioClip flicker;
    public override void Interact()
    {
        animator.SetBool("animate", true);
    }

    public override void Leave()
    {
        animator.SetBool("animate", false);
    }

    public override void TurnOff()
    {
        animator.SetBool("animate", false);
    }

    public override void TurnOn()
    {
        animator.SetBool("animate", true);
        SoundManager.Instance.PlaySound(flicker);
    }
}
