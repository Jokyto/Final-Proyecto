using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast2 : MonoBehaviour
{
   
    [SerializeField]private float raycastDistance = 3f;
    [SerializeField] GameObject cameraSecondRoom;
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

            cameraSecondRoom.SetActive(true);
            cameraPlayer.SetActive(false);
            activated = true;
        }

    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Vector3 puntoB = Vector3.forward * raycastDistance;
        Gizmos.DrawRay(transform.position, puntoB);
    }
}
