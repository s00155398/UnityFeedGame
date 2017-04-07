using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour {

    void Start()
    {

    }
    int speed = 1; // Adjust to make your NPC move however fast you want.


    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
