using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : Furniture
{
    public AudioClip scary;
    public AudioClip beat;

    public override void Interact()
    {
        animator.SetBool("animate", true);
        SoundManager.Instance.PlaySound(beat);
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
        SoundManager.Instance.PlaySound(scary);
    }
}
