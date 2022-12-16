using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    public TextMeshProUGUI timeDisplay;
    public TextMeshProUGUI dayDisplay;

    void OnEnable()
    {
        TimeManager.OnDayChange += UpdateDay;
        TimeManager.OnTimeChange += UpdateTime;
    }
    void OnDisable()
    {
        TimeManager.OnDayChange -= UpdateDay;
        TimeManager.OnTimeChange -= UpdateTime;
    }
    public void UpdateTime(int hours, int mins) // Shows time and day in ui
    {
        timeDisplay.text = string.Format("{0:00}:{1:00}", hours, mins); // The formatting ensures that there will always be 0's in empty spaces

    }
    public void UpdateDay(int days)
    {
        dayDisplay.text = "Day: " + days; // display day counter
    }
}
