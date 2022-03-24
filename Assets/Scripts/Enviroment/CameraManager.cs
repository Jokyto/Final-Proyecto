using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [SerializeField] GameObject cameraFirstRoom;
    [SerializeField] GameObject cameraSecondRoom;
    [SerializeField] GameObject cameraPlayer;

    // Start is called before the first frame update
    void Start()
    {
        //FindObjectOfType<Raycast1>().OnRaycast1Active += EnableCameraFirstRoom;
        FindObjectOfType<Raycast2>().OnRaycast2Active += EnableCameraSecondRoom;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableCameraFirstRoom(){

        cameraFirstRoom.SetActive(true);
        cameraPlayer.SetActive(false);
        Debug.Log("Camera Manager Recibio UnityEvent OnRaycast1Active");
    }

    public void EnableCameraSecondRoom(){

        cameraSecondRoom.SetActive(true);
        cameraPlayer.SetActive(false);
        Debug.Log("Camera Manager Recibio evento OnRaycast2Active");
    }


}
