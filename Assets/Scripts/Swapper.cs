using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerState
{
    Form1,
    Form2
}
public class Swapper : MonoBehaviour
{
        AudioSource source;
        public PlayerState State = PlayerState.Form1;
      
        private Transform lastTransform;
    
    
        // Use this for initialization
        void Start()
        {
          
            source = GetComponent<AudioSource>();
            lastTransform = transform;
            SetState(State, true);
        }

        // Update is called once per frame
        void Update()
        {

       if(GameObject.Find("Scientists").GetComponent<Health>().CurrentHp == 0)
        {
            SceneManager.LoadScene("FailScene");
        }




        if (Input.GetKeyUp(KeyCode.F))
          {
            
            if (State == PlayerState.Form1)
             {
                SetState(PlayerState.Form2, false);
                transform.rotation = Quaternion.Euler(0,0,0);
                source.Play();
              }
            else
              {
                SetState(PlayerState.Form1, false);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                source.Play();
            }

           }
       
       

    }


    GameObject FindExistingPlayer()
    {
        return GameObject.FindGameObjectWithTag("Player");
        
    }
   
    public void SetState(PlayerState newState, bool IsFirstTime)
        {
            State = newState;

            //if it's the first time we are doing this (called from Start above) then there wont be a child object to get a transform from
            if (!IsFirstTime)
            {

            var player = FindExistingPlayer();

            lastTransform = player.transform;
            Destroy(player);
        }
         
           switch (State)
            {
                case PlayerState.Form1:
                    Instantiate(Resources.Load("Prefabs/SpecimenXscorp"), lastTransform.position, lastTransform.rotation);
                  

                break;

                case PlayerState.Form2:
                Instantiate(Resources.Load("Prefabs/BalledForm"), lastTransform.position, lastTransform.rotation);
               

                break;
            }

           
        }
    }
