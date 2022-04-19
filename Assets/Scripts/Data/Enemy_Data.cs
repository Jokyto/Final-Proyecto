using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "Create Enemy Data")]
public class Enemy_Data : ScriptableObject
{
   

    [SerializeField]public float enemyHealth = 500f;
    [SerializeField]public float enemySpeed = 4f;
    [SerializeField]public float chaseDetection = 20f;
    [SerializeField]public float chaseLimit = 2f;
    [SerializeField]public float minimumDistance = 0.1f;
    [SerializeField]public float enemyRotationSpeed = 10f;
    [SerializeField]public float raycastDistance = 1.5f;
    [SerializeField]public float atkCooldown = 2f;



}
