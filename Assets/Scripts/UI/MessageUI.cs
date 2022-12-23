using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MessageUI : MonoBehaviour
{
    public GameObject Inbox;
    public TextMeshProUGUI Text;

    public Sprite Picture;

    public Image image;

    public string msg;

    void Start()
    {
        SetUpMessage(msg, Picture);

    }
    public void SetUpMessage(string msg, Sprite icon)
    {
        image.sprite = icon;
        Text.text = msg;
    }

}
