using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkTo : MonoBehaviour
{
    public PlayerState State = PlayerState.Form1;
    public Transform goal;
    static Animator anim;
    NavMeshAgent agent;
    private Rigidbody rbody;
    private ParticleSystem pSystem;
    public GameObject scientist;
    float volume = 20f;
    public AudioClip scream;
 
    AudioSource source;
    public GameObject specimen;
    Animator specimenAnimator;
    // Use this for initialization
    void Start()
    {
        specimenAnimator = specimen.GetComponent<Animator>();
        pSystem = GetComponent<ParticleSystem>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
        agent.destination = goal.position;
    }

    void Update()
    {
        if (rbody.velocity.magnitude > 0 && rbody.velocity.magnitude <= 5)
        {
            anim.SetBool("IsWalkingTo", true);
        }
        else
        {
            anim.SetBool("IsWalkingTo", false);
        }

        if (rbody.velocity.magnitude > 10)
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {

            anim.SetBool("IsRunning", false);
        }

        if (rbody.velocity.magnitude == 0)
        {
            anim.SetBool("IsIdle", true);
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsWalkingTo", false);
        }


    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "SpecimenXscorp(Clone)" && State == PlayerState.Form1)
        {
           
            pSystem.Play();
                   
            Invoke("Delete",1);
        }
    }
   

    void Delete()
    {
        source.PlayOneShot(scream, volume);
        scientist.SetActive(false);
        GameObject.Find("Scientists").GetComponent<Health>().CurrentHp += 25;
        
    }

}