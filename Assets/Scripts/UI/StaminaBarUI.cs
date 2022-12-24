using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBarUI : MonoBehaviour
{
    public Slider slider;

    void OnEnable()
    {
        StaminaController.OnStaminaUse += UpdateBar;
        StaminaController.OnStaminaRestore += UpdateBar;
    }
    void OnDisable()
    {
        StaminaController.OnStaminaUse -= UpdateBar;
        StaminaController.OnStaminaRestore -= UpdateBar;
    }
    void Start()
    {
        slider.value = StaminaController.Stamina / StaminaController.MaxStamina;
    }
    public void UpdateBar(float amount)
    {
        slider.value = amount / StaminaController.MaxStamina;
    }

}
