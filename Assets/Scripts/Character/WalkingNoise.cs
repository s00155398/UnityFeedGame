using UnityEngine;
using System.Collections;

public class WalkingNoise : MonoBehaviour {
    public PlayerState State = PlayerState.Form1;   

    AudioSource source;

    
    // Use this for initialization
    void Start () {
       source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.F))
        {
            if (State == PlayerState.Form1)
            {
                State = PlayerState.Form2;
            }
            else
            {
                State = PlayerState.Form1;
            }
        }


        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) && State == PlayerState.Form1)
        {          
            source.Play();
            source.loop = true;		
        }

        if(Input.GetKeyUp(KeyCode.W) || State != PlayerState.Form1)
        {
            source.Stop();
            source.loop = false;
        }
        if (Input.GetKeyUp(KeyCode.S) || State != PlayerState.Form1)
        {
            source.Stop();
            source.loop = false;
        }
    }
}
