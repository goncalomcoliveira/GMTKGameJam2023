using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bath : Furniture
{
    public GameObject ladder;
    public AudioClip audioClip;

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
        ladder.SetActive(false);
    }

    public override void TurnOn()
    {
        ladder.SetActive(true);
    }
}
