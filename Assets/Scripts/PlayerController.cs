using UnityEngine;

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



    private CharacterController controller;
    public Vector3 velocity;
    private bool jump = false;
    public Transform cameraTransform;
    public Camera CameraSettings;
    

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        

    }

    void Update()
    {

        HandleJump();
        HandleMovement();
        HandleCrouch();
 


        //Gravity

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);


        //Show mouse again
        if (Input.GetKey(KeyCode.Escape)){

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

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





