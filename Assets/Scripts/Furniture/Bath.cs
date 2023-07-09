using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bath : Furniture
{
    public SpriteRenderer ladder;
    private bool noLadder;
    public Sprite ladderSprite;
    private SpriteRenderer child;
    public AudioClip bubbles;
    public AudioClip death;


    public override void Interact()
    {
        animator.SetBool("animate", true);

        child = GameObject.FindGameObjectsWithTag("child")[0].GetComponent<SpriteRenderer>();
        child.enabled = false;
        
        if (noLadder)
        {
            deathManager.BathDeath();
            SoundManager.Instance.PlaySound(death);
        }
    }

    public override void Leave()
    {
        animator.SetBool("animate", false);
        child.enabled = true;
    }

    public override void TurnOff()
    {
        ladder.sprite = ladderSprite;
        noLadder= false;
    }

    public override void TurnOn()
    {
        ladder.sprite = null;
        noLadder = true;
        SoundManager.Instance.PlaySound(bubbles);
    }
}
