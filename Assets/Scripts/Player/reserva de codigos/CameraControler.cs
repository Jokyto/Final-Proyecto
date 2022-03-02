using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{

    [SerializeField] GameObject[] cameras;

    // Start is called before the first frame update
    void Start()
    {
        EnableCamera(0, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            EnableCamera(0, true);
            EnableCamera(1, false);
         

        };
        if (Input.GetKeyDown(KeyCode.F2))
        {
            EnableCamera(0, false);
            EnableCamera(1, true);
           

        };
     

    }
    void EnableCamera(int position, bool status)
    {
        cameras[position].SetActive(status);
    }
}
