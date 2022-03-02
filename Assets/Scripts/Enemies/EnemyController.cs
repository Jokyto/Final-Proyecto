using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    private  enum Behaviours
    {
        caged,
        highHealth,
        lowHealth,
    }

    private Behaviours behaviour;
    public float enemyHealth;
    [SerializeField] private float enemySpeed = 2f;
    [SerializeField] private float chaseDetection = 30f;
    [SerializeField] private float chaseLimit = 10f;
    [SerializeField] private float minimumDistance = 3f;
    [SerializeField] private float enemyRotationSpeed = 10f;
    [SerializeField] private float cooldown= 2f;

    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private GameObject enemyShootPoint;
    [SerializeField] private GameObject player;

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
        EnemyHeathState();

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
                chaseDetection = 100f;
                chaseLimit = minimumDistance;
                enemySpeed = 4f;
                break;

            default:
                Debug.Log("Error");
                break;


        }
    }

    private void AttackPlayer()
    {
        if((Vector3.Distance(gameObject.transform.position, player.transform.position) <= minimumDistance && lowHealth && canattack))
        {
            EnemyAnimator.SetBool("JumpAttack",true);
            cooldown =6f;

            //EnemyAnimator.SetBool("JumpAttack",false);
        }
    }

    private void EnemyCooldown()
    {
        if (!canshoot || !canattack)
        {

            cooldown -= Time.deltaTime;

            if (cooldown <= 0f)
            {
                canshoot = true;
                canattack = true;
            }

        };
    }

    private void ShootPlayer()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= chaseLimit && !lowHealth && canshoot)
        {
            EnemyAnimator.SetBool("isCasting", true);
            Instantiate(enemyBullet, enemyShootPoint.transform.position, enemyShootPoint.transform.rotation);
            canshoot = false;
            cooldown = 6f;
            //EnemyAnimator.SetBool("isCasting", false);

        };

    }

    void LookAtPlayer()
    {

        Quaternion newRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, enemyRotationSpeed * Time.deltaTime);
    }

    void MoveTowardsPlayer()
    {
        Vector3 deltaVector = player.transform.position - transform.position;
        Vector3 direction = deltaVector.normalized;

        if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= chaseDetection /*&& 
        Vector3.Distance(gameObject.transform.position, player.transform.position) >= chaseLimit*/)
        {
        
        transform.position += direction * enemySpeed * Time.deltaTime;
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
            enemyHealth -= 100f;
        };
    }

    private void EnemyHeathState()

    {
        if(enemyHealth >500 && isFree){

            behaviour = Behaviours.highHealth;
        }

        if (enemyHealth < 500f && enemyHealth >0f && isFree)
        {
            lowHealth = true;
            behaviour = Behaviours.lowHealth;
        };

        if (enemyHealth <= 0f)
        {
            muerto = true;
            //Destroy(gameObject);
        }else {
            muerto = false;
        }
    }
}


