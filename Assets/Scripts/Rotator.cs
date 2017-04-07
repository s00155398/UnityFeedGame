using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {
    public float rotateX;
    public float rotateY;
    public float rotateZ;
    void Start()
    {
       
    }
	
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(rotateX,rotateY,rotateZ) * Time.deltaTime);
    }
}
