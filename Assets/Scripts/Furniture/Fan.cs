using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : Furniture
{
    public AudioClip turnOn;

    public override void Interact()
    {
        animator.SetBool("animate", true);
        SoundManager.Instance.PlaySound(turnOn);
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
        SoundManager.Instance.PlaySound(turnOn);
    }
}
