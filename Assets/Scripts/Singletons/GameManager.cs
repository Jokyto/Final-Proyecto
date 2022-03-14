using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int mana = 300;
    public float playerHealth = 1000;
    public bool muerto = false;
    public bool haveMana;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        DeadOrAlive();
        ManaCount();
    }

    private void ManaCount()
    {
        if (mana >= 10)
        {
            haveMana = true;
        }
        else{
            haveMana = false;
        }
    }

    private void DeadOrAlive()
    {
        if (playerHealth <= 0f)
        {
            muerto = true;
        }
        else
        {
            muerto = false;
        }
    }
}
