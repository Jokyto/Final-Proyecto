using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWall : MonoBehaviour
{
 
    void Start()
    {
        FindObjectOfType<EnemyController>().OnBossDeath += DestroyWall;
    }
        public void DestroyWall()
    {
        Destroy(gameObject, 2f);
    }
}
