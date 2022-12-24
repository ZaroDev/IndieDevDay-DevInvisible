using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaController : GameSystem
{
    [SerializeField]
    public static float MaxStamina = 700f;
    public static float Stamina = 700f;

    public static Action<float> OnStaminaUse;
    public static Action<float> OnStaminaRestore;
    public static void Use(float amount)
    {
        if (Stamina > 0) Stamina -= amount;
        Mathf.Clamp(Stamina, 0, MaxStamina);
        OnStaminaUse?.Invoke(Stamina);

    }
    public static void RestoreStamina(float amount)
    {
        if (Stamina < 700) Stamina += amount;
        OnStaminaRestore?.Invoke(Stamina);
    }

    public float GetStamina()
    {
        return Stamina;
    }
}
