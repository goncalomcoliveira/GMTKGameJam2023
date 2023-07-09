using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public Room room;
    public Money MoneyManager;
    private int money;

    public GameObject panel;
    public GameObject[] FurnitureList;

    public Image Sprite;
    public TMP_Text priceText;

    public Image posSprite;

    public Image preSprite;

    private int cont;
    private int poscont;
    private int precont;

    private GameObject inBuildFurniture;

    public void Start()
    {
        cont = 0;
        poscont = 1;
        precont = FurnitureList.Length - 1;
        Close();
    }
    public void Open()
    {
        panel.SetActive(true);
        Show();
    }
    public void Close()
    {
        panel.SetActive(false);
    }
    public void Next()
    {
        cont++;
        poscont++;
        precont++;
        if (precont >= FurnitureList.Length)
        {
            precont = 0;
        }
        if (cont >= FurnitureList.Length)
        {
            cont = 0;
        }
        if (poscont >= FurnitureList.Length)
        {
            poscont = 0;
        }
        Show();
    }
    public void Previous()
    {
        cont--;
        precont--;
        poscont--;
        if (precont < 0)
        {
            precont = FurnitureList.Length - 1;
        }
        if (cont < 0)
        {
            cont = FurnitureList.Length - 1;
        }
        if (poscont < 0)
        {
            poscont = FurnitureList.Length - 1;
        }
        Show();
    }
    public void Show()
    {
        preSprite.sprite = FurnitureList[precont].GetComponent<SpriteRenderer>().sprite;

        Sprite.sprite = FurnitureList[cont].GetComponent<SpriteRenderer>().sprite;
        priceText.text = FurnitureList[cont].GetComponent<Furniture>().Price.ToString();

        posSprite.sprite = FurnitureList[poscont].GetComponent<SpriteRenderer>().sprite;

        preSprite.SetNativeSize();
        Sprite.SetNativeSize();
        posSprite.SetNativeSize();
    }
    public void Buy()
    {
        money = MoneyManager.money;
        if(money >= FurnitureList[cont].GetComponent<Furniture>().Price)
        {
            inBuildFurniture = Instantiate(FurnitureList[cont]);
            inBuildFurniture.GetComponent<Transform>().position = new Vector3(100, 100, 0);
            MoneyManager.Subtract(FurnitureList[cont].GetComponent<Furniture>().Price);
            Close();
            room.BuildModeOn(inBuildFurniture);
        }
    }
    public GameObject GetInBuildFurniture()
    {
        return inBuildFurniture;
    }
}
