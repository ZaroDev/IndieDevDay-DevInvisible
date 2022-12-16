using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DayStateUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Image ndImage;
    public TimeManager timeMange;

    public Sprite[] ndSprite;
    
    
    void Start()
    {
        if (ndSprite != null)
        {
            ndImage.sprite = ndSprite[0];
        }
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(timeMange.GetHours() >= 6 && timeMange.GetHours() < 21)
        {
            ndImage.sprite = ndSprite[0];
        }
        else ndImage.sprite = ndSprite[1];
    }
}
