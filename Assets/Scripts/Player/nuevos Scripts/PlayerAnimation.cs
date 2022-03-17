using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private PlayerMovementScript playerMovement;
    [SerializeField] private PlayerShootScript playerShootScript;
    [SerializeField] PlayerManager playerManager;


    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }


    void Update()
    {
        PlayerMove();
        PlayerJump();
        FallDetection();
        PlayerShoot();
    }

    private void PlayerShoot()
    {



        if (Input.GetKeyDown(KeyCode.Mouse0) && playerShootScript.canshoot && playerManager.haveMana)
        {
            playerAnimator.SetBool("isCasting", true);
        };

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            playerAnimator.SetBool("isCasting", false);
        }
    }

    void PlayerMove()

    {
        if (Input.GetKey(KeyCode.W))
        {
            playerAnimator.SetBool("isWalking", true);
        }; //caminar
        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnimator.SetBool("isWalking", false);
        };


        if (Input.GetKey(KeyCode.S))
        {
            playerAnimator.SetBool("isWalking", true);
            playerAnimator.SetBool("isWalkingBack", true);
        };
        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnimator.SetBool("isWalking", false);
            playerAnimator.SetBool("isWalkingBack", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerAnimator.SetBool("isStrafeLeft", true);
        }; //strafe left
        if (Input.GetKeyUp(KeyCode.A))
        {
            playerAnimator.SetBool("isStrafeLeft", false);
        };

        if (Input.GetKey(KeyCode.D))
        {
            playerAnimator.SetBool("isStrafeRight", true);
        }; //strafe right

        if (Input.GetKeyUp(KeyCode.D))
        {
            playerAnimator.SetBool("isStrafeRight", false);
        };

        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerAnimator.SetBool("isRunning", true);
        };
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerAnimator.SetBool("isRunning", false);
        };


    }

    private void PlayerJump()
    {

        if (Input.GetKey(KeyCode.Space) && playerMovement.IsGrounded)
        {
            playerAnimator.SetBool("isJump", true);
        };
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerAnimator.SetBool("isJump", false);
        }
    }

    private void FallDetection()
    {
        if (playerMovement.IsGrounded)
        {
            playerAnimator.SetBool("isFalling", false);
        }
        else
        {
            playerAnimator.SetBool("isFalling", true);
        }
    }
}
