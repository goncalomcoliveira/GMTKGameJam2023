using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class Furniture : MonoBehaviour
{
    public int r;
    public int l;
    public int Price;
    public int length;
    public List<Quality> qualities = new List<Quality>();
    public GameObject warningPrefab;

    private Warning warning;
    public List<GameObject> actions;

    private static Room room;
    private static Shop shop;
    private static Character character;
    private static TMP_Text panel;
    private static DeathManager deathManager;
    private bool canClick;
    private bool activate;
    public int eletricCost;


    public Animator animator;

    public abstract void TurnOn();
    public abstract void TurnOff();

    public void Start()
    {
        character = GameObject.FindGameObjectsWithTag("character")[0].GetComponent<Character>();
        room = GameObject.FindGameObjectsWithTag("room")[0].GetComponent<Room>();
        shop = GameObject.FindGameObjectsWithTag("shop")[0].GetComponent<Shop>();
        panel = GameObject.FindGameObjectsWithTag("panel")[0].GetComponent<TMP_Text>();
        deathManager = GameObject.FindGameObjectsWithTag("death")[0].GetComponent<DeathManager>();
        animator = gameObject.GetComponent<Animator>();
    }

    public void Update()
    {
        if (activate)
        {
            activate = character.Interrupt(warning);
        }   
    }

    public void Move(float x, float y, int r, int l)
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

        foreach (GameObject obj in actions)
        {
            Action action = Instantiate(obj).GetComponent<Action>();
            action.position = new Position((r==0 || r==10 ? r+1 : r), (l==room.ROOMSIZE-1 || l==6? l-1 : l));
            action.furniture = this;
            ActionManager.AddAction(action);
        }

        if (warningPrefab != null)
        {
            warning = Instantiate(warningPrefab).GetComponent<Warning>();
            warning.position = new Position((r == 0 || r == 10 ? r + 1 : r), (l == room.ROOMSIZE - 1 || l == 6 ? l - 1 : l));
            warning.roomNumber = room.GetRoom(warning.position.x, warning.position.y);
            warning.furniture = this;
        }
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
            panel.text = "";
            panel.GetComponent<RectTransform>().position = transform.position;
        }
    }
    public void OnMouseExit()
    {
        canClick = false;
        panel.text = "";
    }
    public void OnMouseDown()
    {
        if (canClick)
        {
            Activate();
        }
    }
    public bool GetCanClick()
    {
        return canClick;
    }

    public void Activate()
    {
        TurnOn();
        deathManager.Environment(qualities);
        activate = true;
    }

    public void Deactivate()
    {
        TurnOff();
        deathManager.EnvironmentRemove(qualities);
        activate = false;
    }
    public Room GetRoom()
    {
        return room;
    }
    public abstract void Interact();
    public abstract void Leave();
}
