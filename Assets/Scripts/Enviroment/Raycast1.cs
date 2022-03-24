using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast1 : MonoBehaviour
{
     private float raycastDistance = 3f;
    private bool activated = false;

    public event Action OnRaycast1Active;

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
        if (activated) { gameObject.SetActive(false); }
    }

    private void RaycastTrigger()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.forward, out hit, raycastDistance))
        {
            OnRaycast1Active?.Invoke();
            Debug.Log("Raycast1 envio evento OnRaycast1Active");
            activated = true;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 puntoB = Vector3.forward * raycastDistance;
        Gizmos.DrawRay(transform.position, puntoB);
    }










}
