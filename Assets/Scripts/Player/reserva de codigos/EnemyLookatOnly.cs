using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookatOnly : MonoBehaviour
{
   [SerializeField] GameObject player;
    [SerializeField] float lookSpeed = 10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
    }

    void LookAtPlayer(){

        Quaternion newRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, lookSpeed * Time.deltaTime);
    }
}
