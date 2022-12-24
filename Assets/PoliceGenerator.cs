using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceGenerator : MonoBehaviour
{
    public GameObject Polfa;
    public TimeManager timemanager;
    int lastday;
    int day;
    // Start is called before the first frame update
    void Start()
    {
        lastday =timemanager.days;
        day=lastday;

    }

    // Update is called once per frame
    void Update()
    {
        day = timemanager.days;

        if(day != lastday)
        {
            lastday = day;
            Instantiate(Polfa, new Vector3(0,0,0), Quaternion.identity);
        }
    }
}
