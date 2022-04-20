using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FinalBoss Data", menuName = "Create FinalBoss Data")]
public class FinalBoss_Data : ScriptableObject
{

    [SerializeField] public float enemyHealth = 2000;
    [SerializeField] public float meleeLimit = 4f;
    [SerializeField] public float bossRotationSpeed = 10f;
    [SerializeField] public float meleeCooldown = 3f;
    [SerializeField] public float roarCooldown = 6f;
}

