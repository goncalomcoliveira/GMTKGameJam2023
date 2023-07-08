using System.Collections.Generic;
using UnityEngine;

public abstract class Furniture : MonoBehaviour
{
    public int r;
    public int l;
    public int Price;
    public int length;
    public List<Quality> qualities = new List<Quality>();
    public Warning warning;

    private static Room room;
    private static Shop shop;
    private static GameObject panel;
    private static Character character;
    private bool canClick;
    private bool activate;

    public abstract void TurnOn();
    public abstract void TurnOff();

    public void Start()
    {
        character = GameObject.FindGameObjectsWithTag("character")[0].GetComponent<Character>();
        room = GameObject.FindGameObjectsWithTag("room")[0].GetComponent<Room>();
        shop = GameObject.FindGameObjectsWithTag("shop")[0].GetComponent<Shop>();
        panel = GameObject.FindGameObjectsWithTag("panel")[0];
    }

    public void Update()
    {
        if (activate)
        {
            activate = character.Interrupt(warning);
        }   
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
        this.r = r;
        this.l = l;
        Destroy(room.Matrix[r, l]);
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
    }
    public void OnMouseExit()
    {
        canClick = false;
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
        TurnOn();
        DeathManager.Environment(qualities);
        activate = true;
    }

    public void Deactivate()
    {
        TurnOff();
        DeathManager.EnvironmentRemove(qualities);
        activate = false;
    }
}
