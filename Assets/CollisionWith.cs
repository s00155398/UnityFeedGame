using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWith : MonoBehaviour {

    ParticleSystem pSystem;
    AudioSource source;
    public GameObject terminal;

    void Start()
    {
        pSystem = GetComponent<ParticleSystem>();
        source = GetComponent<AudioSource>();
    }
        // Use this for initialization
        void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "BalledForm(Clone)")
        {
            pSystem.Play();
            source.Play();
            Invoke("Delete", 1);
        }
    }
    void Delete()
    {
        terminal.SetActive(false);
    }
}
