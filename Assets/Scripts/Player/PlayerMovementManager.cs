using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementManager : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;
    private Rigidbody rbPlayer;
    [SerializeField] float playerHealth = 1000;

    //variables movimiento
    [SerializeField] private float walkingSpeed = 3f;
    [SerializeField] private float playerRotationSpeed = 300f;
    [SerializeField] private float jumpHeight = 3.5f;

    //variables disparo
    [SerializeField] private float cooldown;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] public GameObject shootPoint1;
  

    // Stats bools
    public bool muerto = false;
    private bool isGrounded;
    private bool canshoot;



    void Start()
    {
        jumpHeight = 3.5f;
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
        PlayerShoot();
        PlayerCooldown();
        DeadOrAlive();

    }

    private void DeadOrAlive()
    {
        if (playerHealth <= 0f)
        {
            muerto = true;
           
        }
        else
        {
            muerto = false;
        }
    }

    private void PlayerCooldown()
    {
        if (!canshoot)
        {

            cooldown -= Time.deltaTime * fireRate;

            if (cooldown <= 0f)
            {
                canshoot = true;

            }

        };
    }

    private void PlayerShoot()
    {



        if (Input.GetKeyDown(KeyCode.Mouse0) && canshoot)
        {
            playerAnimator.SetBool("isCasting", true);
        };

        if (Input.GetKeyUp(KeyCode.Mouse0) && canshoot)
        {
            Instantiate(bulletPrefab, shootPoint1.transform.position, shootPoint1.transform.rotation);
            canshoot = false;
            cooldown = 2f;
            playerAnimator.SetBool("isCasting", false);
        }
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

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            playerHealth -= 50f;

        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            playerHealth -= 150f;
        }
    }









}
