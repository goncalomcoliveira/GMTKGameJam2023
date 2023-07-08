using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class Furniture : MonoBehaviour
{
    private static Room room;
    private static Shop shop;
    private static TMP_Text panel;
    public int r;
    public int l;
    public int Price;
    private bool canClick;
    public int length;
    public int eletricCost;


    public Animator animator;

    public abstract void TurnOn();
    public abstract void TurnOff();

    public void Start()
    {
        room = GameObject.FindGameObjectsWithTag("room")[0].GetComponent<Room>();
        shop = GameObject.FindGameObjectsWithTag("shop")[0].GetComponent<Shop>();
        panel = GameObject.FindGameObjectsWithTag("panel")[0].GetComponent<TMP_Text>();
    }
    public void Move(float x,float y,int r, int l)
    {
        if ((x<0 && l!=6) || r == 10)
        {
            gameObject.GetComponent<Transform>().rotation = new Quaternion(0, 90, 0, 0);
        }
        gameObject.transform.position = new Vector3(x, y, 0);
    }

    public void Build(float x, float y, int r, int l)
    {
        Move(x, y, r, l);
        if(room == null)
        {
            room = GameObject.FindGameObjectsWithTag("room")[0].GetComponent<Room>();
        }
        this.r = r;
        this.l = l;
        room.Destroy(r, l);
        room.Matrix[r, l] = gameObject.GetComponent<Furniture>();
        if(length == 2)
        {
            if ((x < 0 && l != 6) || r == 10)
            {
                room.Destroy(r, l-1);
                room.Matrix[r, l-1] = gameObject.GetComponent<Furniture>();
            }
            else
            {
                room.Destroy(r+1, l);
                room.Matrix[r+1, l] = gameObject.GetComponent<Furniture>();
            }
        }
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
        if(gameObject.GetComponent<Furniture>() is not EmptySpace && gameObject.GetComponent<Furniture>() is not Wall)
        {
            Transform transform = gameObject.GetComponent<Transform>();
            panel.text = eletricCost.ToString();
            panel.GetComponent<RectTransform>().position = transform.position;
            Debug.Log("entered");
        }
    }
    public void OnMouseExit()
    {
        canClick = false;
        panel.text = "";
        Debug.Log("Exited");
    }
    public void OnMouseDown()
    {
        if (canClick)
        {
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
    public void Activate()
    {

    }
}
