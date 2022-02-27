using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] float walkingSpeed = 3f;
    [SerializeField] float playerRotationSpeed = 300f;
    [SerializeField] float gravity = -9.8f;
    [SerializeField] float jumpHeight = 6f;
    private Vector3 velocidadVertical;
    private CharacterController ccPlayer;
    private bool isGrounded;


    void Start()
    {
        ccPlayer = GetComponent<CharacterController>();
        playerAnimator.SetBool ("isRunning", false);
        playerAnimator.SetBool ("isWalking", false);
        
    }


    void Update()
    {
        //Gravedad
        velocidadVertical.y += gravity * Time.deltaTime;
        ccPlayer.Move(velocidadVertical * Time.deltaTime);


        PlayerMove();
        PlayerRotate();
        PlayerJump();

    }

    void PlayerMove()

    {
        if (Input.GetKey(KeyCode.W))
        {
            ccPlayer.Move(transform.TransformDirection(Vector3.forward) * walkingSpeed * Time.deltaTime);
            playerAnimator.SetBool("isWalking", true); 
        }; //caminar
        if (Input.GetKeyUp(KeyCode.W)){
            playerAnimator.SetBool("isWalking", false);
        };


        if (Input.GetKey(KeyCode.S))
        {
            ccPlayer.Move(transform.TransformDirection(Vector3.back) * walkingSpeed * Time.deltaTime);
            playerAnimator.SetBool("isWalking", true);
            playerAnimator.SetBool("isWalkingBack", true);
        }; //retroceder
        if (Input.GetKeyUp(KeyCode.S)){
            playerAnimator.SetBool("isWalking", false);
            playerAnimator.SetBool("isWalkingBack", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            ccPlayer.Move(transform.TransformDirection(Vector3.left) * walkingSpeed * Time.deltaTime);
            playerAnimator.SetBool("isStrafeLeft", true); 
        }; //strafe left
        if (Input.GetKeyUp(KeyCode.A)){
            playerAnimator.SetBool("isStrafeLeft", false);
        };

        if (Input.GetKey(KeyCode.D))
        {
            ccPlayer.Move(transform.TransformDirection(Vector3.right) * walkingSpeed * Time.deltaTime);
            playerAnimator.SetBool("isStrafeRight", true); 
        }; //strafe right

        if (Input.GetKeyUp(KeyCode.D)){
            playerAnimator.SetBool("isStrafeRight", false);
        };

        if (Input.GetKey(KeyCode.LeftShift)){
            playerAnimator.SetBool("isRunning", true);
            walkingSpeed = 7f;
        };
        if (Input.GetKeyUp(KeyCode.LeftShift)){
            playerAnimator.SetBool("isRunning", false);
            walkingSpeed = 3f;
        };


    }

    void PlayerRotate()
    {
        float hAxis = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, hAxis * playerRotationSpeed * Time.deltaTime);

    }

    private void PlayerJump()
    {
        if (Input.GetKey(KeyCode.Space) && ccPlayer.isGrounded)
        //if (Input.GetKey(KeyCode.Space) && isGrounded)
        {

            velocidadVertical.y = Mathf.Sqrt(-jumpHeight * gravity);
            playerAnimator.SetBool("isJump", true);

        };
        if (Input.GetKeyUp(KeyCode.Space)){
            playerAnimator.SetBool("isJump", false);
        }

        if (!ccPlayer.isGrounded){
           playerAnimator.SetBool("isFalling", true); 
        }
        if (ccPlayer.isGrounded){
           playerAnimator.SetBool("isFalling", false); 
        }
    }

   /*private void OnTriggerStay(Collider self)  {
        isGrounded = true;
        playerAnimator.SetBool("falling", false);
    }

   private void OnTriggerExit(Collider self) {
       isGrounded = false;
       playerAnimator.SetBool("falling", true);
   } */




}
