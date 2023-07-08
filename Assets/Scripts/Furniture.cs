using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Furniture : MonoBehaviour
{
    public Sprite RightSprite;
    public Sprite LeftSprite;
    public int Price;

    public abstract void TurnOn();
    public abstract void TurnOff();
    public void Build(bool toTheRight,float x,float y)
    {
        if (toTheRight)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = RightSprite;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = LeftSprite;
        }

        gameObject.transform.position = new Vector3(x, y, 0);
    }
}
