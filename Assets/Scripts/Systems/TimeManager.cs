using UnityEngine;
using UnityEngine.Rendering; // used to access the volume component
using System;

public class TimeManager : GameSystem
{
    public Volume ppv; // this is the post processing volume

    public float tick; // Increasing the tick, increases second rate
    public float seconds;
    public int mins;
    int prevMins;
    public int hours;
    int prevHours;
    public int days = 1;
    int prevDays;
    public bool activateLights; // checks if lights are on
    public GameObject[] lights; // all the lights we want on when its dark
    public SpriteRenderer[] stars; // star sprites
    //Events 
    public static Action<int, int> OnTimeChange;
    public static Action<int> OnDayChange;

    // Start is called before the first frame update
    public void Start()
    {
        ppv = gameObject.GetComponent<Volume>();
    }

    // Update is called once per frame
    public void FixedUpdate() // we used fixed update, since update is frame dependant. 
    {
        CalcTime();
    }

    public void CalcTime() // Used to calculate sec, min and hours
    {
        seconds += Time.fixedDeltaTime * tick; // multiply time between fixed update by tick

        if (seconds >= 60) // 60 sec = 1 min
        {
            seconds = 0;
            mins += 1;
        }

        if (mins >= 60) //60 min = 1 hr
        {
            mins = 0;
            hours += 1;
        }

        if (hours >= 24) //24 hr = 1 day
        {
            hours = 0;
            days += 1;
        }
        ControlPPV(); // changes post processing volume after calculation

        //Events trigger

        if (prevMins != mins || prevHours != hours)
            OnTimeChange?.Invoke(hours, mins);
        if (prevDays != days)
            OnDayChange?.Invoke(days);

        prevDays = days;
        prevHours = hours;
        prevMins = mins;
    }

    public void ControlPPV() // used to adjust the post processing slider.
    {
        //ppv.weight = 0;
        if (hours >= 21 && hours < 22) // dusk at 21:00 / 9pm    -   until 22:00 / 10pm
        {
            ppv.weight = (float)mins / 60; // since dusk is 1 hr, we just divide the mins by 60 which will slowly increase from 0 - 1 
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].color = new Color(stars[i].color.r, stars[i].color.g, stars[i].color.b, (float)mins / 60); // change the alpha value of the stars so they become visible
            }

            if (activateLights == false) // if lights havent been turned on
            {
                if (mins > 45) // wait until pretty dark
                {
                    for (int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(true); // turn them all on
                    }
                    activateLights = true;
                }
            }
        }


        if (hours >= 6 && hours < 7) // Dawn at 6:00 / 6am    -   until 7:00 / 7am
        {
            ppv.weight = 1 - (float)mins / 60; // we minus 1 because we want it to go from 1 - 0
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].color = new Color(stars[i].color.r, stars[i].color.g, stars[i].color.b, 1 - (float)mins / 60); // make stars invisible
            }
            if (activateLights == true) // if lights are on
            {
                if (mins > 45) // wait until pretty bright
                {
                    for (int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(false); // shut them off
                    }
                    activateLights = false;
                }
            }
        }
    }

    public override void Restart()
    {
        days = 1;
        hours = 0;
        mins = 0;
    }
}