using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckifHealth : MonoBehaviour {

	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("Scientists").GetComponent<Health>().dead == true)
        {
            int scene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
	}
}
