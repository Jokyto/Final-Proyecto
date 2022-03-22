using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkeleton : Enemy
{
    [SerializeField] Transform[] waypoints;
    private int currentindex = 0;
    float patrolMinimumDistance = 0.5f;
    bool goBack;
    float enemyspeedwalking = 2f;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        Patrol();
    }

    void Patrol()

    {
        Vector3 deltaVector = waypoints[currentindex].position - transform.position;
        Vector3 direction = deltaVector.normalized;

        

        if (Vector3.Distance(gameObject.transform.position, player.transform.position) >= chaseDetection)
        {
            //Desplazamiento entre waypoints
            transform.position += direction * enemySpeed * Time.deltaTime;
            EnemyAnimator.SetBool("isWalking", true);
            enemySpeed = enemyspeedwalking;

            //orientacion del enemigo
            //transform.forward = Vector3.Lerp(Vector3.forward, direction, enemyRotationSpeed * Time.deltaTime);
             Quaternion newRotation = Quaternion.LookRotation(waypoints[currentindex].position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, enemyRotationSpeed * Time.deltaTime);

            if (deltaVector.magnitude <= patrolMinimumDistance)
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

    public override void MoveTowardsPlayer()
    {
        base.MoveTowardsPlayer();
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= chaseDetection)
        {
            EnemyAnimator.SetBool("isWalking", false);
        }
    }




}
