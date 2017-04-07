using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public PlayerState State = PlayerState.Form1;
    public GameObject camera;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (State == PlayerState.Form2)
        {
            camera.SetActive(true);
        }
        else
        {
            camera.SetActive(false);
        }
	}
}
