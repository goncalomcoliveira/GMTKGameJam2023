using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : Furniture
{
    public Sprite sleep;
    public Sprite awake;
    public AudioClip audioClip;
    private SpriteRenderer child;

    public override void Interact()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sleep;
        SoundManager.Instance.PlaySound(audioClip);
        child = GameObject.FindGameObjectsWithTag("child")[0].GetComponent<SpriteRenderer>();
        child.enabled = false;
    }

    public override void Leave()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = awake;
        child.enabled = true;
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
