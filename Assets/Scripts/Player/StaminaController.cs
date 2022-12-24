using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaController : GameSystem
{
    [SerializeField]
    public static float MaxStamina = 100f;
    public static float Stamina = 100f;

    public static Action<float> OnStaminaUse;
    public static Action<float> OnStaminaRestore;
    public static void Use(float amount)
    {
        Stamina -= amount;
        Mathf.Clamp(Stamina, 0, MaxStamina);
        OnStaminaUse?.Invoke(Stamina);
    }
    public static void RestoreStamina()
    {
        Stamina = MaxStamina;
        OnStaminaRestore?.Invoke(Stamina);
    }
}
