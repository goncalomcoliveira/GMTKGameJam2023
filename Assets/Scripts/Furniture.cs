using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Furniture : MonoBehaviour
{
    private static Room room;
    private static Shop shop;
    private static GameObject panel;
    public int Price;
    private bool canClick;

    public abstract void TurnOn();
    public abstract void TurnOff();

    public void Start()
    {
        room = GameObject.FindGameObjectsWithTag("room")[0].GetComponent<Room>();
        shop = GameObject.FindGameObjectsWithTag("shop")[0].GetComponent<Shop>();
        panel = GameObject.FindGameObjectsWithTag("panel")[0];
    }
    public void Move(float x,float y)
    {
        if (x<0)
        {
            gameObject.GetComponent<Transform>().rotation = new Quaternion(0, 90, 0, 0);
        }
        gameObject.transform.position = new Vector3(x, y, 0);
    }

    public void Build(float x, float y, int r, int l)
    {
        Move(x, y);
        if(room == null)
        {
            room = GameObject.FindGameObjectsWithTag("room")[0].GetComponent<Room>();
        }
        room.Matrix[r, l] = gameObject.GetComponent<Furniture>();
        room.BuildModeOff();
    }
    public Shop GetShop()
    {
        if(shop == null)
        {
            shop = GameObject.FindGameObjectsWithTag("shop")[0].GetComponent<Shop>();
        }
        return shop;
    }
    public void OnMouseEnter()
    {
        canClick = true;
        Debug.Log("Entrou");
    }
    public void OnMouseExit()
    {
        canClick = false;
        Debug.Log("saiu");
    }
    public void OnMouseDown()
    {
        if (canClick)
        {
            Debug.Log("ok");
            ShowPanel();
        }
    }
    public bool GetCanClick()
    {
        return canClick;
    }
    public void ShowPanel()
    {

    }
}
