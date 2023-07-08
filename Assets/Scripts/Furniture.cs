using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Furniture : MonoBehaviour
{
    public GameObject furniture;
    public Sprite RightSprite;
    public Sprite LeftSprite;

    public abstract void TurnOn();
    public abstract void TurnOff();
    public void Build(bool toTheRight,float x,float y)
    {
        if (toTheRight)
        {
            furniture.GetComponent<SpriteRenderer>().sprite = RightSprite;
        }
        else
        {
            furniture.GetComponent<SpriteRenderer>().sprite = LeftSprite;
        }

        furniture.transform.position = new Vector3(x, y, 0);
    }
}
