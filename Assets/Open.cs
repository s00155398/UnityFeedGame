using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open : MonoBehaviour {

    // Use this for initialization
    public GameObject terminal;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
        
	
	
	// Update is called once per frame
	void Update()
    {
        if (terminal.activeSelf == false)
        {
            anim.SetBool("IsOpen", true);
        }
    }

}
