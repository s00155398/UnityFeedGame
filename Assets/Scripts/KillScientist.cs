using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillScientist : MonoBehaviour {
    Health heal;
    public PlayerState State = PlayerState.Form1;
    void Update()
    {
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
    }
   
	
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "SpecimenXscorp" && State == PlayerState.Form1)
        {
            GameObject.Find("Scientists").GetComponent<Health>().CurrentHp += 25; 
            Destroy(gameObject);
        }
    }
}
