using Newtonsoft.Json.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 8f;
    public float dashSpeed = 30f;
    public bool canDash = true;
    public float jumpHeight = 2f;
    public float gravity = -20f;
    public float standingHeight = 2f;
    public float crouchingHeight = 1f;
    public float coyoteTimer = .2f;
    private float dashing = .2f;
    public float currentSpeed;

    public bool isFast = false;



    private CharacterController controller;
    public Vector3 velocity;
    private bool jump = false;
    public Transform cameraTransform;
    public Camera CameraSettings;

    public GameObject spawnPrefab;
    public Quaternion prefabRotation = new Quaternion(0f, 0f, 0f, 0f);
    public Vector3 prefabPosition = new Vector3(-6, 5, 0);
    public bool doPrefabSpawn = false;


    //Timer
    public float timeSpentOnLevel = 0;
    public TextMeshProUGUI timerText;
    public float timeSpentOnLevelRound = 0;


    //Texts

    public TextMeshProUGUI JumpText;
    public TextMeshProUGUI SprintText;
    public TextMeshProUGUI WinText;



    //Respawn
    public Vector3 respawnPos = new Vector3();
    public Transform warp;

    void Start()
    {

        WinText.fontSize = 0;
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        respawnPos = new Vector3(-4.55f, 1.38f, -0.5f);
        if (doPrefabSpawn)
        {
            Instantiate(spawnPrefab, prefabPosition, prefabRotation);
        }
        
        

    }

    void Update()
    {


        //Gravity

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);



        HandleJump();
        HandleMovement();
        HandleCrouch();
 


        


        //Show mouse again
        if (Input.GetKey(KeyCode.Escape))
        {

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;


        }


        //Sho mouse again
        if (Input.GetMouseButtonDown(0))
        {

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;

        }

        //fall reset
        if (transform.position.y < -18)
        {

            transform.position = respawnPos;
        }


        //Manual reset

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        //Timer

        timeSpentOnLevel += Time.deltaTime;
        timeSpentOnLevelRound = Mathf.RoundToInt(timeSpentOnLevel);
        timerText.text = timeSpentOnLevelRound.ToString();


        //Checkpoint switcher

        if (Input.GetKey(KeyCode.T))
        {

            transform.position = warp.position;
        }
    }

    void HandleMovement() {




        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");



        Vector3 direction =
        transform.right * horizontal +
        transform.forward * vertical;



        float currentSpeed = moveSpeed;

        if (Input.GetKey(KeyCode.LeftShift) | (Input.GetMouseButtonDown(1)))
        {

            isFast = true;
            SprintText.fontSize = 0;
          
            if (controller.isGrounded == false && dashing > 0 ) {

                currentSpeed = dashSpeed;
                dashing = dashing - Time.deltaTime;
                

            }

            else
            {
                currentSpeed = sprintSpeed;
                dashing = .2f;
                CameraSettings.fieldOfView = 64;
                

            }

            
            
        }

        else
        {
            isFast= false;
        }



        if (dashing < 0)
        {

            currentSpeed = moveSpeed* Time.deltaTime;
        }
        
        
            
       if (currentSpeed == moveSpeed) {


            CameraSettings.fieldOfView = 60;
       }



        controller.Move(direction * currentSpeed * Time.deltaTime);


    }




    void HandleJump()

    { if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            jump = false;
            

        }





        if (!controller.isGrounded) {
            coyoteTimer = coyoteTimer - Time.deltaTime;

        }
        else
        {
            while (coyoteTimer != .2f) {

                coyoteTimer = .2f;
                canDash = true;

            }
            
        }





        if (Input.GetKey(KeyCode.Space) && coyoteTimer > 0f && !jump)

        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            jump = true;
            JumpText.fontSize = 0;

        }


        if (Input.GetKeyUp(KeyCode.Space))
        {


            velocity.y = velocity.y / 2;
        }

    }





    void HandleCrouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            controller.height = crouchingHeight;
            Debug.Log("crouching");
        }
        else
        {
            controller.height = standingHeight;
        }
    }



    

}





