using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPlatformMovement : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    [SerializeField] private float speed;
    private int currentindex = 0;
    [SerializeField] float minimumDistance = 0.5f;
    [SerializeField] float rotationSpeed;
    bool goBack;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlatformMovement();
    }




    private void PlatformMovement()
    {
        Vector3 deltaVector = waypoints[currentindex].position - transform.position;
        Vector3 direction = deltaVector.normalized;

        //Desplazamiento entre waypoints
        transform.position += direction * speed * Time.deltaTime;
        //orientacion de la plataforma.

        if (deltaVector.magnitude <= minimumDistance)
        {
            if (currentindex >= waypoints.Length - 1)
            {
                goBack = true;
            }
            else if (currentindex <= 0)
            {
                goBack = false;
            }

            if (goBack)
            {
                currentindex--;
            }
            else
            {
                currentindex++;
            }
        }
    }
}
