using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public GameObject floor;
    public GameObject basement;
    bool IsBasement = false;
    void Start()
    {
        basement.gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            SwitchFloor();
        }
    }

    void SwitchFloor()
    {
        if (IsBasement)
        {
            basement.SetActive(false);
            floor.SetActive(true);
        }
        else
        {
            basement.SetActive(true);
            floor.SetActive(false);
        }
        IsBasement = !IsBasement;
    }

}
