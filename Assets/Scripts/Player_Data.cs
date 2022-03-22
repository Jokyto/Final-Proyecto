using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Data", menuName = "Create Player Data")]
public class Player_Data : ScriptableObject
{
    [SerializeField] int hp = 5;
    [SerializeField] float Speed = 2f;
    [SerializeField] int Mana = 100;
    [SerializeField] int Magic_armor = 3;


}
