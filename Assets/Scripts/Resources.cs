using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
