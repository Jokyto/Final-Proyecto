using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraView : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float cameraRotationSpeed = 10f;
    float xRotation = 0f;


    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerCameraVerticalRotate();
    }
    void PlayerCameraVerticalRotate()
    {

        float MouseY = Input.GetAxis("Mouse Y") * cameraRotationSpeed * Time.deltaTime;

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -40f, 45f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        if (Input.GetMouseButtonDown(1))
        {

            //Cursor.lockState = CursorLockMode.None;
            
        }

    }
}
