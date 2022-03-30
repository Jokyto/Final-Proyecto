using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    [SerializeField] private float walkingSpeed = 3f;
     public float WalkingSpeed { get => walkingSpeed; set => walkingSpeed = value; }
    [SerializeField] private float playerRotationSpeed = 300f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] PlayerCollision playerCollision;
    private float gravity = -9.8f;
    private Vector3 velocidadVertical;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;
    private bool isGrounded;
    private CharacterController ccPlayer;

    public bool IsGrounded { get => isGrounded; set => isGrounded = value; }
   

    // Start is called before the first frame update
    void Start()
    {
        ccPlayer = GetComponent<CharacterController>();

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
        velocidadVertical.y += gravity * Time.deltaTime;
        ccPlayer.Move(velocidadVertical * Time.deltaTime);
    }



    void PlayerMove()

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


    }




    void PlayerRotate()
    {
        float hAxis = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, hAxis * playerRotationSpeed * Time.deltaTime);
    }

    private void PlayerJump()
    {


        if (Input.GetKey(KeyCode.Space) && IsGrounded)
        {
            velocidadVertical.y = Mathf.Sqrt(-jumpHeight * gravity);
            //ccPlayer.Move(velocidadVertical *Time.deltaTime);
        };

    }
}


