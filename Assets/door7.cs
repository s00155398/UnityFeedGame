using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door7 : MonoBehaviour {

    // Use this for initialization
    static Animator anim;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.gameObject.CompareTag("Player") || col.gameObject.gameObject.CompareTag("Scientist"))
        {
            anim.SetBool("IsOpening", true);
        }

    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.gameObject.CompareTag("Player") || col.gameObject.gameObject.CompareTag("Scientist"))
        {
            anim.SetBool("IsOpening", false);
        }

    }
}
