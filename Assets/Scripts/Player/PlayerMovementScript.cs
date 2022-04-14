using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] PlayerCollision playerCollision;
    [SerializeField] Animator playerAnimator;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;

    private CharacterController ccPlayer;
    private float walkingSpeed = 3f;
    private float playerRotationSpeed = 300f;
    private float jumpHeight = 3f;
    private float gravity = -9.8f;
    private Vector3 velocidadVertical;

    private bool isGrounded;
    public bool IsGrounded { get => isGrounded; set => isGrounded = value; }
    public float PlayerRotationSpeed { get => playerRotationSpeed; set => playerRotationSpeed = value; }
    public float WalkingSpeed { get => walkingSpeed; set => walkingSpeed = value; }
    public float JumpHeight { get => jumpHeight; set => jumpHeight = value; }
    public float Gravity { get => gravity; set => gravity = value; }


    // Start is called before the first frame update
    void Start()
    {
        ccPlayer = GetComponent<CharacterController>();
        playerAnimator = GetComponent<Animator>();
        transform.position = FindObjectOfType<Savepoint_Manager>().get_savepoint(GameManager.instance.last_sp).position;

    }

    // Update is called once per frame
    void Update()
    {
        GravityAcceleration();
        PlayerMove();
        PlayerRotate();
        PlayerJump();
        GroundCheck();
    }

    private void GroundCheck()
    {
        IsGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (IsGrounded && velocidadVertical.y < 0f)
        {
            velocidadVertical.y = -2f;
        }
    }

    private void GravityAcceleration()
    {
        velocidadVertical.y += Gravity * Time.deltaTime;
        ccPlayer.Move(velocidadVertical * Time.deltaTime);
    }



    public void PlayerMove()

    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical);
        ccPlayer.Move(transform.TransformDirection(direction) * WalkingSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            WalkingSpeed = 7f;
        };
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            WalkingSpeed = 3f;
        };

        playerAnimator.SetFloat("VelX", horizontal);
        playerAnimator.SetFloat("VelY", vertical);

    }




    void PlayerRotate()
    {
        float hAxis = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, hAxis * PlayerRotationSpeed * Time.deltaTime);
    }

    private void PlayerJump()
    {


        if (Input.GetKey(KeyCode.Space) && IsGrounded)
        {
            velocidadVertical.y = Mathf.Sqrt(-JumpHeight * Gravity);
           
        };

    }
}


