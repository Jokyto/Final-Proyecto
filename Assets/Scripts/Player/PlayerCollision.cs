using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PlayerManager playerManager;
    public event Action onGetDamage;
    private bool CanTakeDamage= true;


     private void OnControllerColliderHit(ControllerColliderHit hit){

     Debug.Log(name + " COLISION CON " + hit.gameObject.name);
    
    
       if (hit.gameObject.CompareTag("EnemyBullet"))
        {
            playerManager.playerHealth -= 50f;
           
        }
        if (hit.gameObject.CompareTag("Enemy") && CanTakeDamage)
        {
            StartCoroutine(DamagePlayer());
        }
    }

    IEnumerator DamagePlayer()
    {
        
        playerManager.playerHealth -= 70f;        
        onGetDamage?.Invoke();
        CanTakeDamage= false;
        yield return new WaitForSeconds(1f);
        CanTakeDamage = true;
             
    }

}
