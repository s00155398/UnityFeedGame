using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stutter : MonoBehaviour {


    public Light light;
    // Use this for initialization


    // Update is called once per frame
    void Update()
    {

        if (light.enabled == true)
        {
            Invoke("off", 1);
        }
        else
        {
            Invoke("on", 1);
        }

        
    }
    void off()
    {
        light.enabled = false;
    }
    void on()
    {
        light.enabled = true;
    }
}

