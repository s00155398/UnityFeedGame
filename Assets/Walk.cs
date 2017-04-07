using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{

    public GameObject player;
    AudioSource source;
    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && player.activeSelf == true)
        {

            source.Play();
            source.loop = true;

        }
        else if (Input.GetKeyUp(KeyCode.W) || player.activeSelf != true)
        {
            source.Stop();
            source.loop = false;
        }
    }
}
