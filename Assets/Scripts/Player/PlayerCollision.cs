using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PlayerManager playerManager;
    public event Action onGetDamage;
    private bool CanTakeDamage = true;


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        Debug.Log(name + " COLISION CON " + hit.gameObject.name);



        if (hit.gameObject.CompareTag("Enemy") && CanTakeDamage)
        {
            StartCoroutine(DamagePlayer());
        }

        if (gameObject.CompareTag("Savepoint"))
        {
            Debug.Log("UN CHECK POINT");
            Savepoint_Manager manager_sp = transform.parent.GetComponent<Savepoint_Manager>();
            manager_sp.Find_savepoint(name);
        }
    }

    IEnumerator DamagePlayer()
    {

        playerManager.playerHealth -= 100f;
        onGetDamage?.Invoke();
        CanTakeDamage = false;
        yield return new WaitForSeconds(1f);
        CanTakeDamage = true;

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            playerManager.playerHealth -= 75f;

        }

    }

}
