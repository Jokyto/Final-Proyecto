using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PlayerManager playerManager;
    

    private void Start() {

        
        
    }

     private void OnControllerColliderHit(ControllerColliderHit hit){

     Debug.Log(name + " COLISION CON " + hit.gameObject.name);
    
    
       if (hit.gameObject.CompareTag("EnemyBullet"))
        {
            playerManager.playerHealth -= 50f;
           
        }
        if (hit.gameObject.CompareTag("Enemy"))
        {
            playerManager.playerHealth -= 70f;
           
        }
    }
}
