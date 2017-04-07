using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AvoidPlayer : MonoBehaviour {

    private Transform Player;
    private NavMeshAgent NavAgent;
    private float turnT;
    private Transform firstTransform;

    public float multiplyBy;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player").transform;

        NavAgent = this.GetComponent<NavMeshAgent>();

        RunAway();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > turnT)
        {
            RunAway();
        }
	}
    public void RunAway()
    {
        firstTransform = transform;

        transform.rotation = Quaternion.LookRotation(transform.position - Player.position);

        Vector3 runTowards = transform.position + transform.forward * multiplyBy;

        NavMeshHit Hit;

        NavMesh.SamplePosition(runTowards, out Hit, 5, 1 << NavMesh.GetAreaFromName("Default"));


        turnT = Time.time + 5;

        transform.position = firstTransform.position;

        transform.rotation = firstTransform.rotation;


        NavAgent.SetDestination(Hit.position);


    }
}
