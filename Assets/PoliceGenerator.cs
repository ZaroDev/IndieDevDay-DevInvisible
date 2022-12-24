using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceGenerator : MonoBehaviour
{
    public GameObject Polfa;
    public GameObject target;
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
        Vector3 center = target.transform.position;

        if(day != lastday)
        {
            Vector3 pos = RandomCircle(center, 12.0f);
             
             
            lastday = day;
            if(day>3)
            {
                Instantiate(Polfa, pos, Quaternion.identity);
                Instantiate(Polfa, new Vector3(pos.x+1,pos.y-2,pos.z), Quaternion.identity);
            }
            else Instantiate(Polfa, pos, Quaternion.identity);
        }
    }

    Vector3 RandomCircle ( Vector3 center ,   float radius  ){
         float ang = Random.value * 360;
         Vector3 pos;
         pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
         pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
         pos.z = center.z;
         return pos;
     }
}
