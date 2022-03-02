using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraView : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float cameraRotationSpeed = 10f;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerCameraVerticalRotate();
    }
    void PlayerCameraVerticalRotate()
    {

        float hAxis = Input.GetAxis("Mouse Y");
        float ejevertical = Mathf.Clamp(hAxis, -31f, 41f) * cameraRotationSpeed;
        transform.Rotate(Vector3.left, ejevertical * Time.deltaTime);


    }
}
