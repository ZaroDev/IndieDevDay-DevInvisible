using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MoneyUI : MonoBehaviour
{
    public Image moneyImg;
    public Sprite[] moneySprites;

    public TextMeshProUGUI moneyDisplay;
    void OnEnable()
    {
        MoneyManager.OnMoneyAdd += DisplayMoney;
        MoneyManager.OnMoneySubstract += DisplayMoney;
    }
    void OnDisable()
    {
        MoneyManager.OnMoneyAdd -= DisplayMoney;
        MoneyManager.OnMoneySubstract -= DisplayMoney;
    }
    void Start()
    {
        if (moneySprites != null)
        {
            moneyImg.sprite = moneySprites[0];
        }
        
    }

    void FixedUpdate()
    {
        MoneyManager.AddMoneyAmount(1);


        if (MoneyManager.GetMoneyAmount() > 500)
        {
            moneyImg.sprite = moneySprites[1];
        }
        if (MoneyManager.GetMoneyAmount() > 1000)
        {
            moneyImg.sprite = moneySprites[2];
        }
        // if (MoneyManager.GetMoneyAmount() > 1100)
        // {
        //     MoneyManager.SubstractMoneyAmount(600);
        // }
    }

    void DisplayMoney(int money)
    {
        float mon = money;
        if(money>999 && money<=9999) moneyDisplay.text = "$ " + (mon/1000).ToString("F1") + "K";
        else if(money>9999) moneyDisplay.text = "$ " + (mon/1000).ToString("F0") + "K";
        else moneyDisplay.text = "$ " + money;
    }
}
