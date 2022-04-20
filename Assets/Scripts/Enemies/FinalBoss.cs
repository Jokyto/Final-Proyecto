using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public event Action OnFinalBossDeath;
    private Animator bossAnimator;
    private Rigidbody rbBoss;
    private bool canMelee;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject firebreath;
    [SerializeField] protected FinalBoss_Data bossStats;



    void Start()
    {
        // FindObjectOfType<EnemyController>().OnBossDeath += StartBattle;
        bossAnimator = GetComponent<Animator>();
        rbBoss = GetComponent<Rigidbody>();
        canMelee = true;

    }


    void Update()
    {
        LookAtPlayer();
        AttackPlayer();
        Death();
    }



    //*****************************************************************************************

    void LookAtPlayer()
    {
        Quaternion newRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, bossStats.bossRotationSpeed * Time.deltaTime);
    }

    private void AttackPlayer()
    {
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) <= bossStats.meleeLimit && canMelee)
        {
            StartCoroutine(MeleeAtkCoroutine(bossStats.meleeCooldown));
        }
        else
        {
            StartCoroutine(RoarAtkCoroutine(bossStats.roarCooldown));
        }
    }
    private void Death()
    {
        if (bossStats.enemyHealth <= 0f)
        {
            OnFinalBossDeath?.Invoke();
            Debug.Log("FinalBoss Envió Evento OnFinalBossDeath");
            Destroy(gameObject, 1);
        }
    }

    IEnumerator MeleeAtkCoroutine(float time)
    {
        canMelee = false;
        bossAnimator.SetTrigger("MeleeAtk");
        yield return new WaitForSeconds(time);
        canMelee = true;
    }

    IEnumerator RoarAtkCoroutine(float time)
    {
        
        bossAnimator.SetTrigger("RoarAtk");
        yield return new WaitForSeconds(1.5f);
        firebreath.SetActive(true);
        yield return new WaitForSeconds(3f);
        firebreath.SetActive(false);
        yield return new WaitForSeconds(time);
        Debug.Log("Ataque ranged");

    }
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            bossStats.enemyHealth -= 100f;
        }
    }
}
