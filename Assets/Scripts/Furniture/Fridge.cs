using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : Furniture
{
    public Sprite open;
    public Sprite closed;
    public AudioClip eatSound;
    public AudioClip openSound;
    public override void Interact()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = open;
        SoundManager.Instance.PlaySound(eatSound);
    }

    public override void Leave()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = closed;
    }

    public override void TurnOff()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = closed;
    }

    public override void TurnOn()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = open;
        SoundManager.Instance.PlaySound(openSound);
    }
}
