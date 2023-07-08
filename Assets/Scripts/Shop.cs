using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public GameObject MoneyManager;
    public int money;

    public GameObject panel;
    public Furniture[] FurnitureList;

    public Image Sprite;
    public TMP_Text priceText;

    public Image posSprite;
    public TMP_Text pospriceText;

    public Image preSprite;
    public TMP_Text prepriceText;

    private int cont;
    private int poscont;
    private int precont;

    public void Start()
    {
        cont = 0;
        poscont = 1;
        precont = FurnitureList.Length - 1;
        Open();
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
        cont--;
        precont--;
        poscont--;
        if (precont < 0)
        {
            precont = FurnitureList.Length -1;
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
    public void Previous()
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
    public void Show()
    {
        preSprite.sprite = FurnitureList[precont].LeftSprite;
        prepriceText.text = FurnitureList[precont].Price.ToString();

        Sprite.sprite = FurnitureList[cont].LeftSprite;
        priceText.text = FurnitureList[cont].Price.ToString();

        posSprite.sprite = FurnitureList[poscont].LeftSprite;
        pospriceText.text = FurnitureList[poscont].Price.ToString();
    }
    public void Buy()
    {
        if(money >= FurnitureList[cont].Price)
        {

        }
    }
}
