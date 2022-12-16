using System;
using UnityEngine;

public class MoneyManager : GameSystem
{
    private static int moneyAmount = 9000;
    public static Action<int> OnMoneyAdd;
    public static Action<int> OnMoneySubstract;

    public static void AddMoneyAmount(int amount)
    {
        moneyAmount += amount;
        OnMoneyAdd?.Invoke(moneyAmount);
    }
    public static void SubstractMoneyAmount(int amount)
    {
        moneyAmount -= amount;
        OnMoneySubstract?.Invoke(moneyAmount);
    }

    public static int GetMoneyAmount()
    {
        return moneyAmount;
    }
    public override void Restart()
    {
        moneyAmount = 0;
    }
}

