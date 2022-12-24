using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreTriggerUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject StoreUIPanel;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player") StoreUIPanel.SetActive(true);
    }

    private void OnTriggerExit2D()
    {
        StoreUIPanel.SetActive(false);
    }
}
