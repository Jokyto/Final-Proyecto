using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class DestroyRune2 : MonoBehaviour
{
    
    [SerializeField] private UnityEvent SecondDoorDestroy;

   private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("PlayerBullet"))
        {
           SecondDoorDestroy?.Invoke();
           Debug.Log("Totem envio Unityevent a door2");
           Destroy(gameObject);
        };
    }

}
