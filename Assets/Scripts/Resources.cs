using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public static class MoneyResource
{
    private static int moneyAmount;
    
    public static void AddMoneyAmount(int amount)
    {
        moneyAmount += amount;        
    }

    public static int GetMoneyAmount()
    {
        return moneyAmount;
    }

}

public class Resources : MonoBehaviour
{
    public Image moneyImg;
    public Sprite[] moneySprites;

    public TextMeshProUGUI moneyDisplay;
    
    void start()
    {
        if(moneySprites != null)
        {
            moneyImg.sprite = moneySprites[0];
        }
        
    }
    
    void FixedUpdate()
    {
        MoneyResource.AddMoneyAmount(1);
        DisplayMoney();

        if(MoneyResource.GetMoneyAmount()>500)
        {
            moneyImg.sprite = moneySprites[1];
        }
        if(MoneyResource.GetMoneyAmount()>1000)
        {
            moneyImg.sprite = moneySprites[2];
        }
    }

    void DisplayMoney()
    {
        moneyDisplay.text = "$ "+MoneyResource.GetMoneyAmount();
    }
}