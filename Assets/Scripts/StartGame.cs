using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

    public Animation anim;
    public GameObject Player;
    public GameObject Camera;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animation>();
        anim.Play("Fly");
        Invoke("SetCharacter",30);
	}
	
	// Update is called once per frame
	void SetCharacter()
    {
        Player.SetActive(true);
        Camera.SetActive(false);
    }
}
