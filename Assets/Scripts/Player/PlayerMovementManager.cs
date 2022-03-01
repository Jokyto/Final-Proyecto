using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private float walkingSpeed = 3f;
    [SerializeField] private float playerRotationSpeed = 300f;
    [SerializeField] private float jumpHeight = 6f;
    private bool isGrounded;
    private Rigidbody rbPlayer;


    void Start()
    {

        playerAnimator.SetBool("isRunning", false);
        playerAnimator.SetBool("isWalking", false);
        rbPlayer = GetComponent<Rigidbody>();
    }


    void Update()
    {


        PlayerMove();
        PlayerRotate();
        PlayerJump();
        FallDetection();

    }

    void PlayerMove()

    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * walkingSpeed * Time.deltaTime);
            playerAnimator.SetBool("isWalking", true);
        }; //caminar
        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnimator.SetBool("isWalking", false);
        };


        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * walkingSpeed * Time.deltaTime);
            playerAnimator.SetBool("isWalking", true);
            playerAnimator.SetBool("isWalkingBack", true);
        }; //retroceder
        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnimator.SetBool("isWalking", false);
            playerAnimator.SetBool("isWalkingBack", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * walkingSpeed * Time.deltaTime);
            playerAnimator.SetBool("isStrafeLeft", true);
        }; //strafe left
        if (Input.GetKeyUp(KeyCode.A))
        {
            playerAnimator.SetBool("isStrafeLeft", false);
        };

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * walkingSpeed * Time.deltaTime);
            playerAnimator.SetBool("isStrafeRight", true);
        }; //strafe right

        if (Input.GetKeyUp(KeyCode.D))
        {
            playerAnimator.SetBool("isStrafeRight", false);
        };

        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerAnimator.SetBool("isRunning", true);
            walkingSpeed = 7f;
        };
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
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

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rbPlayer.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);

            playerAnimator.SetBool("isJump", true);

        };
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerAnimator.SetBool("isJump", false);
        }
    }

    private void FallDetection()
    {
        if (isGrounded)
        {
            playerAnimator.SetBool("isFalling", false);
        }
        else
        {
            playerAnimator.SetBool("isFalling", true);
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("colision con piso");
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("sin colision con piso");
        }
    }











}
