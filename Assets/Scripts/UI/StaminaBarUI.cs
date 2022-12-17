using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBarUI : MonoBehaviour
{
    public Slider StaminaBar;

    private int maxStamina = 100;
    private int currentStamina;

    public static StaminaBarUI instance;

    private void Awake()
    {
        instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        StaminaBar.maxValue = maxStamina;
        StaminaBar.value = maxStamina;
    }

    public void UseStamina(int stamina)
    {
        if((currentStamina - stamina) >= 0 )
        {
            currentStamina -= stamina;
            StaminaBar.value = currentStamina;
        }
        

    }
    
    
    // Update is called once per frame
    
}
