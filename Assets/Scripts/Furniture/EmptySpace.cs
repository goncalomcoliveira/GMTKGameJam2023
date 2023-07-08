using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptySpace : Furniture
{
    public Sprite BuildSquare;
    private bool inBuild;
    private GameObject inBuildFurniture;
    public override void TurnOff()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = null;
        inBuild = false;
    }

    public override void TurnOn()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = BuildSquare;
        inBuild = true;
        inBuildFurniture = GetShop().GetInBuildFurniture();
    }

    public void OnMouseDown()
    {
        if (inBuild)
        {
            float x = gameObject.transform.position.x;
            float y = gameObject.transform.position.y;
            inBuildFurniture.GetComponent<Furniture>().Build(x, y, r, l);
        }
    }
}
