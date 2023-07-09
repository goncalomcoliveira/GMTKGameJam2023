using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySpace : Furniture
{
    public Sprite BuildSquare;
    private bool inBuild;
    private GameObject inBuildFurniture;
    public AudioClip audioClip;
    public override void TurnOff()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = null;
        inBuild = false;
        animator.SetBool("animate", false);
    }

    public override void TurnOn()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = BuildSquare;
        inBuild = true;
        inBuildFurniture = GetShop().GetInBuildFurniture();
        animator.SetBool("animate", true);
    }

    public void OnMouseDown()
    {
        if (GetRoom().GetInBuild())
        {
            float x = gameObject.transform.position.x;
            float y = gameObject.transform.position.y;
            if(inBuildFurniture == null)
            {
                inBuildFurniture = GetShop().GetInBuildFurniture();
            }
            inBuildFurniture.GetComponent<Furniture>().Build(x, y, r, l);
        }
    }
    public void OnMouseEnter()
    {
        
    }

    public override void Interact()
    {
    }

    public override void Leave()
    {
    }
}
