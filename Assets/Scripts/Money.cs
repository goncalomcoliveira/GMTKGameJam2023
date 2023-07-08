using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{
    public int money;
    public int growthRate;

    public TMP_Text MoneyText;

    private float timer;

    public void Start()
    {
        MoneyText.text = money.ToString();
    }
    void Update()
    {
        float interval = 3f;
        timer += Time.deltaTime;
        while (timer > interval)
        {
            Add(growthRate);
            timer -= interval;
        }
    }
    public void Add(int quantity)
    {
        money += quantity;
        MoneyText.text = money.ToString();
    }
    public void Subtract(int quantity)
    {
        money -= quantity;
        MoneyText.text = money.ToString();
    }
}
