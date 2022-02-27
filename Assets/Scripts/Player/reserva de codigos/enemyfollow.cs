using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyfollow : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject player;
    [SerializeField] float enemyMovementSpeed = 10f;
    [SerializeField] float chaseDistance = 2f;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(gameObject.transform.position, player.transform.position) >= chaseDistance)
        {
            MoveTowardsPlayer();
        };
    }

    void MoveTowardsPlayer()
    {

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemyMovementSpeed * Time.deltaTime);

    }
}
