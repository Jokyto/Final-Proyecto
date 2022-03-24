using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyRune : MonoBehaviour
{
  
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("PlayerBullet"))
        {
           Destroy(gameObject);
        };
    }
}
