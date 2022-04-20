using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFinalRune : MonoBehaviour
{

    public event Action onFinalRuneDestroyed;

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            onFinalRuneDestroyed?.Invoke();
            Debug.Log("Runa final destruida");
            Destroy(gameObject,0.5f);
        };
    }
}

