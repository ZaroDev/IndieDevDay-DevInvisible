using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndingScreenScore : MonoBehaviour
{
    public TextMeshProUGUI moneyDisplay;
    // Start is called before the first frame update
    void Start()
    {
        float money = MoneyManager.GetMoneyAmount();
        float mon = money;
        if(money>999 && money<=9999) moneyDisplay.text = "Score: $ " + (mon/1000).ToString("F1") + "K";
        else if(money>9999) moneyDisplay.text = "Score: $ " + (mon/1000).ToString("F0") + "K";
        else moneyDisplay.text = "Score: $ " + money;
    }
}
    
