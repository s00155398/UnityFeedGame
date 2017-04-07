using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CubeMove : MonoBehaviour {

    public PlayerState State = PlayerState.Form1;   
    AudioSource source1,source2;
    static Animator anim;
    [System.Serializable]
    public class MoveSettings // settings for movement
    {
        public float forwardvel = 1;
        public float rotateVel = 100;
        public float jumpVel = 25;
        public float groundDist = .5f;
        public float climbSpeed = 10f;
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
     
   // for the glass that we swap to 
   //speed needed to break the glass
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
        var  sources = GetComponents<AudioSource>();
      
        anim = GetComponent<Animator>();

        source1 = sources[0];
        source2 = sources[1];
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
        JumpCheck();
        RunCheck();


       
    }

   

    void JumpCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {     
         anim.SetBool("IsJumping", true);
            source2.Play();     
        }
        else if (Grounded())
        {                         
            anim.SetBool("IsJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.Space)) 
        {
            anim.Play("Jump");
        }
    }
   
    
    void RunCheck()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("IsWalking", true);
             
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("IsWalking", false);          
        }

        if (Input.GetKeyDown(KeyCode.W) && Grounded())
        {

            source1.Play();
            source1.loop = true;
            anim.SetBool("IsWalking", true);

        }
        else if (Input.GetKeyUp(KeyCode.W) || !Grounded())
        {
            source1.Stop();
            source1.loop = false;
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
       
        if (jumpInput > 0 && Grounded() && State == PlayerState.Form1)
        { //jump
            velocity.y = moveSetting.jumpVel;
        }
        else if (jumpInput == 0 && Grounded())
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
       
       
        if (col.gameObject.CompareTag("End"))
        {
            SceneManager.LoadScene("EndScene");
        }
        if (col.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene("EndScene");
        }
        if (col.gameObject.CompareTag("Scientist"))
        {
            anim.Play("Attack");    
        }
        if (col.gameObject.CompareTag("endlvl1"))
        {
            SceneManager.LoadScene("Level2_1");
        }

    }

   
    }
   

