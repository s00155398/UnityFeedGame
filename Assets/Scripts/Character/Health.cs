using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {
    public PlayerState State = PlayerState.Form1;

    public float TotalHp;
    public float CurrentHp;
    public bool dead;
    public float degen = 1;    
     GameObject HealthBar;
	// Use this for initialization
	void Start () {
        CurrentHp = TotalHp;
        HealthBar = GameObject.Find("Health");
	}
	
	// Update is called once per frame
	void Update () {
        if (CurrentHp > TotalHp)
        {
            CurrentHp = TotalHp;
        }
       
        if (dead == false)
        {
            Degen();
        }
       
	}

    void Degen()
    {
        CurrentHp -= (degen * Time.deltaTime);
        HealthBar.transform.localScale = new Vector3(1, (CurrentHp / TotalHp), 1);

        if (CurrentHp <= 0)
        {
            dead = true;
        }
        if (CurrentHp > TotalHp)
        {
            CurrentHp = TotalHp;
        }
    }   

}
