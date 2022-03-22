using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    // Variables

    [SerializeField] protected GameObject player;
    protected float enemyHealth = 500f;
    protected float enemySpeed = 4f;
    protected float chaseDetection = 20f;
    protected float chaseLimit = 2f;
    protected float minimumDistance = 1f;
    protected float enemyRotationSpeed = 10f;
    protected bool muerto = false;
    protected Animator EnemyAnimator;
    protected Rigidbody rbEnemy;




    public virtual void Start()
    {
        EnemyAnimator = GetComponent<Animator>();
        rbEnemy = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        LookAtPlayer();
        MoveTowardsPlayer();
        EnemyHealthState();

    }

    public void LookAtPlayer()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= chaseDetection)
        {
            Quaternion newRotation = Quaternion.LookRotation(player.transform.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, enemyRotationSpeed * Time.deltaTime);
        }
    }

    public virtual void MoveTowardsPlayer()
    {
        Vector3 deltaVector = player.transform.position - transform.position;
        Vector3 direction = deltaVector.normalized;

        if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= chaseDetection &&
        Vector3.Distance(gameObject.transform.position, player.transform.position) >= chaseLimit)
        {

            transform.position += direction * enemySpeed * Time.deltaTime;
            Debug.Log(this.name + " CHASING PLAYER");
            EnemyAnimator.SetBool("isRunning", true);
            enemySpeed = 4f;
    
        }else{
          EnemyAnimator.SetBool("isRunning", false);  
        }

    }

    public void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            enemyHealth -= 100f;
        };
    }

    public void EnemyHealthState()

    {

        if (enemyHealth <= 0f)
        {
            muerto = true;
            Destroy(gameObject);
        }
        else
        {
            muerto = false;
        }
    }

}
