using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : MonoBehaviour {
    Health heal;
    public PlayerState State = PlayerState.Form1;
  
    // Use this for initialization
    void Start () {
        heal.CurrentHp = heal.TotalHp;
    }
	
	// Update is called once per frame
	void Update () {
       
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player") && State == PlayerState.Form1)
        {
            heal.CurrentHp += 25;
            Destroy(gameObject);
        }
    }
}
