using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightsHandler : MonoBehaviour
{
    public bool green = false;


    // Update is called once per frame
    void Update()
    {
        if( Random.value < 0.001 )
        {
            green = !green;
            //Debug.Log(green);
        }
    }

    public bool GetLight()
    {
        return green;
    }
}
