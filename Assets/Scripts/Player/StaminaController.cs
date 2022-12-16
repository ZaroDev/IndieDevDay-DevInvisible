using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaController : MonoBehaviour
{
    public float maxStamina = 100f;
    float stamina;
    void Start()
    {
        stamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RestoreStamina()
    {
        stamina = maxStamina;
    }
}
