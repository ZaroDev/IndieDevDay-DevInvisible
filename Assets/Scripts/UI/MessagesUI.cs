using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagesUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject MessageMenu;
    


    private bool toggleMessageMenu;

    void Start()
    {
        toggleMessageMenu = false;
    }
    public void ToggleMenu()
    {
        if(toggleMessageMenu)
        {
            toggleMessageMenu = false;
            MessageMenu.SetActive(false);

        }   
        else if(!toggleMessageMenu)
        {
            toggleMessageMenu = true;
            MessageMenu.SetActive(true);
        }
    }


    

    
}
