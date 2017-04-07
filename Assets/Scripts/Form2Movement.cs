using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Form2Movement : MonoBehaviour
{
    public PlayerState State = PlayerState.Form1;
    public float crashSpeed;
    public Transform brokenObject;
    Animator anim;
    AudioSource source;

   

    [System.Serializable]
    public class MoveSettings // settings for movement
    {
        public float forwardvel = 1;
        public float rotateVel = 100;
        public float jumpVel = 25;
        public float groundDist = .5f;
        public LayerMask ground;
    }
    [System.Serializable]
    public class PhysSettings
    {
        public float downAccel = 0.75f; // downward force
    }

    [System.Serializable]
    public class InputSettings // detecting input
    {
        public float inputDelay = 0.1f;
        public string FORWARD_AXIS = "Vertical";
        public string TURN_AXIS = "Horizontal";
        public string JUMP_AXIS = "Jump";
    }

    public MoveSettings moveSetting = new MoveSettings();
    public PhysSettings physSetting = new PhysSettings();
    public InputSettings inputSetting = new InputSettings();
    Vector3 velocity = Vector3.zero;
    float forwardInput, turnInput, jumpInput;
    Health bar;


    Quaternion targetRotation;
    private Rigidbody rbody;

    public Quaternion TargetRotation
    {
        get { return targetRotation; }
    }







    void Start()
    {
        rbody = GetComponent<Rigidbody>();

        targetRotation = transform.rotation;

        forwardInput = turnInput = jumpInput = 0;

        anim = GetComponent<Animator>();

      var  sources = GetComponents<AudioSource>();

        source = sources[1];
    }
    void GetInput()
    {
        forwardInput = Input.GetAxis(inputSetting.FORWARD_AXIS);//interpolated
        turnInput = Input.GetAxis(inputSetting.TURN_AXIS);//interpolated
        jumpInput = Input.GetAxisRaw(inputSetting.JUMP_AXIS);//non - interpolated
    }

    void Update()
    {

        GetInput();
        Turn();
        RollCheck();

      
    }



    void RollCheck()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("IsRolling", true);

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("IsRolling", false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("IsReversing", true);

        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("IsReversing", false);
        }

    }

    void FixedUpdate()
    {
        Run();
        Jump();

        rbody.velocity = transform.TransformDirection(velocity);
    }
    bool Grounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, moveSetting.groundDist, moveSetting.ground);
    }

    void Jump()
    {

        if (jumpInput == 0 && Grounded())
        {//zero out velocity.y
            velocity.y = 0;
        }
        else
        {//decrease velocity.y
            velocity.y -= physSetting.downAccel;
        }

    }
    void Run()
    {
        if (Mathf.Abs(forwardInput) > inputSetting.inputDelay)
        {
            velocity.z = moveSetting.forwardvel * forwardInput;

        }
        else
        {
            velocity.z = 0;
        }
    }
    void Turn()
    {
        if (Mathf.Abs(turnInput) > inputSetting.inputDelay)
        {
            targetRotation *= Quaternion.AngleAxis(moveSetting.rotateVel * turnInput * Time.deltaTime, Vector3.up);
        }

        transform.rotation = targetRotation;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("glass") && State == PlayerState.Form2 && rbody.velocity.magnitude > crashSpeed)
        {
            source.Play();
            Destroy(col.gameObject);
            Instantiate(brokenObject, col.gameObject.transform.position, col.gameObject.transform.rotation);
            brokenObject.localScale = col.transform.localScale;

        }

        if (col.gameObject.CompareTag("endlvl1"))
        {
            SceneManager.LoadScene("Level2_1");
        }
        if (col.gameObject.CompareTag("End"))
        {
            SceneManager.LoadScene("EndScene");
        }
        if (col.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("EndScene");
        }
    }
}
