using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bath : Furniture
{
    public SpriteRenderer ladder;
    private bool inBath;
    public Sprite ladderSprite;
    public override void Interact()
    {
        animator.SetBool("animate", true);
        character.GetComponent<GameObject>().SetActive(false);
    }

    public override void Leave()
    {
        animator.SetBool("animate", false);
        character.GetComponent<GameObject>().SetActive(true);
    }

    public override void TurnOff()
    {
        ladder.sprite = null;
        inBath = false;
    }

    public override void TurnOn()
    {
        ladder.sprite = ladderSprite;
        inBath = true;
    }
}
