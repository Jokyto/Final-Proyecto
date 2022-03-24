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

    private enum Behaviours
    {
        caged,
        highHealth,
        lowHealth,
    }

    private Behaviours behaviour;
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
        bossStats.cooldown = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyHealthState();

        switch (behaviour)
        {
            case Behaviours.caged:
                LookAtPlayer();
                break;

            case Behaviours.highHealth:
                LookAtPlayer();
                MoveTowardsPlayer();
                ShootPlayer();
                EnemyCooldown();
                AttackPlayer();
                break;

            case Behaviours.lowHealth:
                LookAtPlayer();
                MoveTowardsPlayer();
                EnemyCooldown();
                AttackPlayer();
                bossStats.chaseDetection = 100f;
                bossStats.chaseLimit = bossStats.minimumDistance;
                bossStats.enemySpeed = 4f;
                break;

            default:
                Debug.Log("Error");
                break;


        }
    }


    private void EnemyCooldown()
    {
        if (bossStats.cooldown >= 0f) //&& !canshoot || !canattack)
        {

            bossStats.cooldown -= Time.deltaTime;
            EnemyAnimator.SetBool("isCasting", false);
            EnemyAnimator.SetBool("JumpAttack", false);
            canattack = false;
            canshoot = false;
        }

        if (bossStats.cooldown <= 0f)
        {
            canshoot = true;
            canattack = true;
        }


    }

    private void AttackPlayer()
    {
        if ((Vector3.Distance(gameObject.transform.position, player.transform.position) <= bossStats.minimumDistance && lowHealth && canattack))
        {
            EnemyAnimator.SetBool("isRunning", false);
            EnemyAnimator.SetBool("JumpAttack", true);
            bossStats.cooldown = 6f;
            canattack = false;

        }
    }

    private void ShootPlayer()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= bossStats.chaseLimit && !lowHealth && canshoot)
        {
            EnemyAnimator.SetBool("isRunning", false);
            EnemyAnimator.SetBool("isCasting", true);
            Instantiate(enemyBullet, enemyShootPoint.transform.position, enemyShootPoint.transform.rotation);
            //canshoot = false;
            bossStats.cooldown = 4f;


        };

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

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Ground")
        {
            isFree = true;
        }

    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("PlayerBullet") && isFree)
        {
            bossStats.enemyHealth -= 100f;
        };
    }

    private void EnemyHealthState()

    {
        if (bossStats.enemyHealth > 500 && isFree)
        {

            behaviour = Behaviours.highHealth;
        }

        if (bossStats.enemyHealth < 500f && bossStats.enemyHealth > 0f && isFree)
        {
            lowHealth = true;
            behaviour = Behaviours.lowHealth;
        };

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
}


