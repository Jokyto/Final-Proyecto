using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast1 : MonoBehaviour
{
    [SerializeField]private float raycastDistance = 10f;
    private int playerLayer = 3;
    [SerializeField] GameObject cameraFirstRoom;
    [SerializeField] GameObject cameraPlayer;
    private bool activated = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastTrigger();
        OneTimeUse();
    }

    private void OneTimeUse()
    {
        if(activated){gameObject.SetActive(false);}
    }

    private void RaycastTrigger()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, Vector3.forward,out hit, raycastDistance)){

            cameraFirstRoom.SetActive(true);
            Debug.Log("raycast 1 toco al player y activo la camarafirstroom");
            activated = true;
        }

    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Vector3 puntoB = Vector3.forward * raycastDistance;
        Gizmos.DrawRay(transform.position, puntoB);
    }
 









}
