using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Television : Furniture
{
    public AudioClip staticSound;
    public AudioClip sound;
    public override void Interact()
    {
        animator.SetBool("interact", true);
        SoundManager.Instance.PlaySound(sound);
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
        SoundManager.Instance.PlaySound(staticSound);
    }
}
