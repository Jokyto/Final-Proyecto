using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Boss Data", menuName = "Create Boss Data")]
public class Boss_Data : ScriptableObject
{

    [SerializeField] public float enemyHealth;
    [SerializeField] public float enemySpeed = 4f;
    [SerializeField] public float chaseDetection = 30f;
    [SerializeField] public float chaseLimit = 2f;
    [SerializeField] public float minimumDistance = 1f;
    [SerializeField] public float enemyRotationSpeed = 10f;
    [SerializeField] public float Meleecooldown = 6f;
    [SerializeField] public float Castcooldown = 4f;
}
