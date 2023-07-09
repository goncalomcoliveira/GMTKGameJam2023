using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : Furniture
{
    public Sprite sleep;
    public Sprite awake;
    public AudioClip audioClip;

    public override void Interact()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sleep;
        SoundManager.Instance.PlaySound(audioClip);
    }

    public override void Leave()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = awake;
    }
    public override void TurnOff()
    {
    }

    public override void TurnOn()
    {
    }

    public void OnMouseEnter()
    {
        
    }
    public void OnMouseDown()
    {
        
    }
}
