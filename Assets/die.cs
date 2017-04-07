using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class die : MonoBehaviour {
    public PlayerState State = PlayerState.Form1;
    private ParticleSystem pSystem;

    public GameObject scientist;
    float volume = 40;
  
    AudioSource scream,cry;

   
    // Use this for initialization
    void Start () {
      var  sources = GetComponents<AudioSource>();
        pSystem = GetComponent<ParticleSystem>();

        scream = sources[0];
        cry = sources[1];
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "SpecimenXscorp(Clone)" && State == PlayerState.Form1)
        {

            pSystem.Play();
            scream.Play();
            Invoke("Delete", 2);
        }
    }
    void Delete()
    {
       
        scientist.SetActive(false);
        GameObject.Find("Scientists").GetComponent<Health>().CurrentHp += 5;

    }
}
