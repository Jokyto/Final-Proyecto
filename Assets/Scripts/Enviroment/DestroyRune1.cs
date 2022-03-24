using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class DestroyRune1 : MonoBehaviour
{

[SerializeField] private UnityEvent FirstDoorDestroy;

   private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("PlayerBullet"))
        {
           FirstDoorDestroy?.Invoke();
           Debug.Log("Totem envio Unityevent a door1");
           Destroy(gameObject);
        };
    }
}
