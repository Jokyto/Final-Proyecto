using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isGrounded;
    [SerializeField] GameManager gameManager;

private void Start() {
    isGrounded = true;
}

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("colision con piso");
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("sin colision con piso");
        }
    }

   private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            gameManager.playerHealth -= 50f;

        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameManager.playerHealth -= 150f;
        }
    }
}
