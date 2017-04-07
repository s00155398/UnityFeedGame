using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject player;
    private Vector3 offset;
   void start()
    {
        offset = transform.position;
    }
    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
