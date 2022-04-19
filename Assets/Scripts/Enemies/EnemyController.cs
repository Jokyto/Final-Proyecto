using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update



    [SerializeField] protected Boss_Data bossStats;

    public event Action OnBossDeath;

    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private GameObject enemyShootPoint;
    [SerializeField] private GameObject player;


    private Behaviours behaviour;
    private enum Behaviours
    {
        caged,
        highHealth,
        lowHealth
    }


    private Animator EnemyAnimator;
    private Rigidbody rbEnemy;
    private bool isFree = false;
    private bool lowHealth = false;
    private bool canshoot = true;
    private bool canattack = true;
    public bool muerto = false;






    void Start()
    {
        EnemyAnimator = GetComponent<Animator>();
        rbEnemy = GetComponent<Rigidbody>();
        isFree = false;
        behaviour = Behaviours.caged;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyHealthState();
    }


    private void AttackPlayer()
    {
        RaycastHit hit;

        // Vector3 raycastDirection = enemyShootPoint.transform.position - transform.position; 

        if (Physics.Raycast(enemyShootPoint.transform.position, enemyShootPoint.transform.forward, out hit, bossStats.raycastDistance) && canattack)
        {
            StartCoroutine(AttackCoroutine(bossStats.Meleecooldown));
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 puntoB = enemyShootPoint.transform.forward * bossStats.raycastDistance;
        Gizmos.DrawRay(enemyShootPoint.transform.position, puntoB);
    }

    private void ShootPlayer()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= bossStats.chaseLimit && behaviour == Behaviours.highHealth && canshoot)
        {
            StartCoroutine(CastCoroutine(bossStats.Castcooldown));
        }

    }

    void LookAtPlayer()
    {
        Quaternion newRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, bossStats.enemyRotationSpeed * Time.deltaTime);
    }

    void MoveTowardsPlayer()
    {
        Vector3 deltaVector = player.transform.position - transform.position;
        Vector3 direction = deltaVector.normalized;

        if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= bossStats.chaseDetection &&
        Vector3.Distance(gameObject.transform.position, player.transform.position) >= bossStats.chaseLimit)
        {

            transform.position += direction * bossStats.enemySpeed * Time.deltaTime;
            Debug.Log("CHASING PLAYER");
            EnemyAnimator.SetBool("isRunning", true);
        };

    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("PlayerBullet") && isFree)
        {
            bossStats.enemyHealth -= 100f;
        };
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Ground")
        {
            isFree = true;
        }

    }


    private void EnemyHealthState()

    {
        switch (behaviour)
        {
            case Behaviours.caged:
                LookAtPlayer();
                break;

            case Behaviours.highHealth:
                LookAtPlayer();
                MoveTowardsPlayer();
                ShootPlayer();
                AttackPlayer();
                break;

            case Behaviours.lowHealth:
                LookAtPlayer();
                MoveTowardsPlayer();
                AttackPlayer();
                bossStats.chaseDetection = 100f;
                bossStats.chaseLimit = 0f;
                bossStats.enemySpeed = 4f;
                break;

            default:
                Debug.Log("Error");
                break;

        }
            Debug.Log(behaviour);

        if (bossStats.enemyHealth > 500f && isFree)
        {
            behaviour = Behaviours.highHealth;
        }

        if (bossStats.enemyHealth < 500f && bossStats.enemyHealth > 0f && isFree)
        {
            lowHealth = true;

            behaviour = Behaviours.lowHealth;
        
        }

        if (bossStats.enemyHealth <= 0f)
        {
            OnBossDeath?.Invoke();
            Debug.Log("Boss Envió Evento OnBossDeath");
            muerto = true;
        }
        else
        {
            muerto = false;
        }
    }

    IEnumerator AttackCoroutine(float time)
    {
        canattack = false;
        EnemyAnimator.SetTrigger("TriggerAttack");    
        yield return new WaitForSeconds(time);
        canattack = true;
    }

    IEnumerator CastCoroutine(float time)
    {
        canshoot = false;
        EnemyAnimator.SetBool("isRunning", false);
        EnemyAnimator.SetTrigger("CastAttack");
        Instantiate(enemyBullet, enemyShootPoint.transform.position, enemyShootPoint.transform.rotation);
        Debug.Log("instancio bala");
        yield return new WaitForSeconds(time);
        canshoot = true;
    }



}


