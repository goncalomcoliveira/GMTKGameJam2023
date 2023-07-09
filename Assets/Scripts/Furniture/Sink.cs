using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink : Furniture
{
    public AudioClip water;
    public override void Interact()
    {
        animator.SetBool("interact", true);
        SoundManager.Instance.PlaySound(water);
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
        SoundManager.Instance.PlaySound(water);
    }
}
