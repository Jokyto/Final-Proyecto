using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableEnemy : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] float enemyMovementSpeed = 10f;
    [SerializeField] float chaseDistance = 2f;
    [SerializeField] float lookSpeed = 10;


    enum Comportamiento
    {

        soloMirar,
        mirarYPerseguir,

    }

    [SerializeField] Comportamiento comportamiento;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (comportamiento)
        {
            case Comportamiento.soloMirar:
                LookAtPlayer();
                break;

            case Comportamiento.mirarYPerseguir:
                LookAtPlayer();
                MoveTowardsPlayer();
                break;
            default:
                Debug.Log("Error");
                break;


        }
    }
    void LookAtPlayer()
    {

        Quaternion newRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, lookSpeed * Time.deltaTime);
    }

    void MoveTowardsPlayer()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) >= chaseDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, enemyMovementSpeed * Time.deltaTime);
        };


    }
}
