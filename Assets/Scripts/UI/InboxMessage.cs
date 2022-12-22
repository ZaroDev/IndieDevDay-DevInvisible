using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InboxMessage : MonoBehaviour
{
    public GameObject MessageInbox;

    public GameObject prefab;
    public TextMeshProUGUI message;
    
   
    // Start is called before the first frame update
    void Start()
    {
        //message = prefab.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        for (int i = 0; i < 2; i++)

            CreateMessage("hola");
    }

    public void CreateMessage(string msg)
    {
        GameObject g;
        g = Instantiate(prefab, MessageInbox.transform);
        
    }

    // Update is called once per frame

}
