using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaController : MonoBehaviour
{
    public static float MaxStamina = 100f;
    static float stamina;

    public static Action<float> OnStaminaUse;
    public static Action<float> OnStaminaRestore;
    void Start()
    {
        stamina = MaxStamina;
    }

    public void Use(float amount)
    {
        stamina -= amount;
        Mathf.Clamp(stamina, 0, MaxStamina);
        OnStaminaUse?.Invoke(stamina);
    }
    public static void RestoreStamina()
    {
        stamina = MaxStamina;
        OnStaminaRestore?.Invoke(stamina);
    }
}
