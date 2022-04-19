using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    // Variables

    /* // DESIGN DATA
    protected float enemyHealth = 500f;
    protected float enemySpeed = 4f;
    protected float chaseDetection = 20f;
    protected float chaseLimit = 2f;
    protected float minimumDistance = 1f;
    protected float enemyRotationSpeed = 10f; */

    [SerializeField] protected Enemy_Data enemyStats;


    [SerializeField] protected GameObject player;
    [SerializeField] protected GameObject enemyMeleeDistance;

    protected bool muerto = false;
    protected bool canattack;
    protected Animator EnemyAnimator;
    protected Rigidbody rbEnemy;




    public virtual void Start()
    {
        EnemyAnimator = GetComponent<Animator>();
        rbEnemy = GetComponent<Rigidbody>();
        canattack = true;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        LookAtPlayer();
        MoveTowardsPlayer();
        EnemyHealthState();
        AttackPlayer();

    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 puntoB = enemyMeleeDistance.transform.forward * enemyStats.raycastDistance;
        Gizmos.DrawRay(enemyMeleeDistance.transform.position, puntoB);
    }

  public virtual void AttackPlayer()
    {
        RaycastHit hit;

        if (Physics.Raycast(enemyMeleeDistance.transform.position, enemyMeleeDistance.transform.forward, out hit, enemyStats.raycastDistance) && canattack)
        {
            StartCoroutine(AttackCoroutine(enemyStats.atkCooldown));
        }
    }

    public void LookAtPlayer()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= enemyStats.chaseDetection)
        {
            Quaternion newRotation = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, enemyStats.enemyRotationSpeed * Time.deltaTime);
        }
    }

    public virtual void MoveTowardsPlayer()
    {
        Vector3 deltaVector = player.transform.position - transform.position;
        Vector3 direction = deltaVector.normalized;

        if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= enemyStats.chaseDetection &&
        Vector3.Distance(gameObject.transform.position, player.transform.position) >= enemyStats.chaseLimit)
        {

            transform.position += direction * enemyStats.enemySpeed * Time.deltaTime;
            Debug.Log(this.name + " CHASING PLAYER");
            EnemyAnimator.SetBool("isRunning", true);
            enemyStats.enemySpeed = 4f;
    
        }else{
          EnemyAnimator.SetBool("isRunning", false);  
        }

    }

    public void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            enemyStats.enemyHealth -= 100f;
        };
    }

    public void EnemyHealthState()

    {

        if (enemyStats.enemyHealth <= 0f)
        {
            muerto = true;
            Destroy(gameObject);
        }
        else
        {
            muerto = false;
        }
    }

    IEnumerator AttackCoroutine(float time)
    {
        canattack = false;
        //EnemyAnimator.SetTrigger("TriggerAttack");   

        // Hacer el salto hacia adelante. 
        yield return new WaitForSeconds(time);
        canattack = true;
    }

    
        
}
