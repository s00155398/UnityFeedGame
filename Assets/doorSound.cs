using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorSound : MonoBehaviour {

    AudioSource source;
    float sound = 8;
    void Start()
    {      
        source = GetComponent<AudioSource>();
        
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            source.Play();
        }

    }
    
	
}
