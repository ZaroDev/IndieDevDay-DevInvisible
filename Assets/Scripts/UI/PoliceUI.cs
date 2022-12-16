using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class PoliceUI : MonoBehaviour
{
    public Image policeImg;
    public Sprite[] policeSprites;

    void Start()
    {
        if (policeSprites != null)
        {
            policeImg.sprite = policeSprites[0];
        }

    }
    void FixedUpdate()
    {
        
        if (MoneyManager.GetMoneyAmount() > 1000)
        {
            policeImg.sprite = policeSprites[2];
        }
        else if (MoneyManager.GetMoneyAmount() > 500)
        {
            policeImg.sprite = policeSprites[1];
        }
        else policeImg.sprite = policeSprites[0];
        
    }

}