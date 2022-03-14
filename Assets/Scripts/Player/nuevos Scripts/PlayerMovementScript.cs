using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    [SerializeField] private float walkingSpeed = 3f;
    [SerializeField] private float playerRotationSpeed = 300f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] PlayerCollision playerCollision;
    private float gravity = -9.8f;
    private Vector3 velocidadVertical;

    private CharacterController ccPlayer;

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
    }

    private void GravityAcceleration()
    {
      velocidadVertical.y += gravity * Time.deltaTime;
      ccPlayer.Move(velocidadVertical * Time.deltaTime);
    }

    void PlayerMove()

    {
        if (Input.GetKey(KeyCode.W))
        {
            ccPlayer.Move(transform.TransformDirection(Vector3.forward) * walkingSpeed * Time.deltaTime);
           
        }; //caminar

        if (Input.GetKey(KeyCode.S))
        {
            ccPlayer.Move(transform.TransformDirection(Vector3.back) * walkingSpeed * Time.deltaTime);
        }; //retroceder
     
        
        if (Input.GetKey(KeyCode.A))
        {
            ccPlayer.Move(transform.TransformDirection(Vector3.left) * walkingSpeed * Time.deltaTime);
        } //strafe left
   

        if (Input.GetKey(KeyCode.D))
        {
            ccPlayer.Move(transform.TransformDirection(Vector3.right) * walkingSpeed * Time.deltaTime);
 
        }; //strafe right

        if (Input.GetKey(KeyCode.LeftShift))
        {
            walkingSpeed = 7f;
        };
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
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
        

        if (Input.GetKey(KeyCode.Space) && playerCollision.isGrounded)
        {
            velocidadVertical.y = Mathf.Sqrt(-jumpHeight*gravity);    
            ccPlayer.Move(velocidadVertical *Time.deltaTime);
        };

    }
}


