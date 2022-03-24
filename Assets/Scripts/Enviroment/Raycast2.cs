using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Raycast2 : MonoBehaviour
{
   
    private float raycastDistance = 3f;
 
    private bool activated = false;
    public event Action OnRaycast2Active;


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

            OnRaycast2Active?.Invoke();
            activated = true;
            Debug.Log("Raycast2 envio evento OnRaycast2Active");
        }

    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Vector3 puntoB = Vector3.forward * raycastDistance;
        Gizmos.DrawRay(transform.position, puntoB);
    }
}
