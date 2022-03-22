using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public float mana = 300f;
    public float manaRegenRate = 0.5f;
    public float playerHealth = 1000;
    public bool muerto = false;
    public bool haveMana;
    [SerializeField] HealthBar Healthbar;

    // Start is called before the first frame update
    void Start()
    {

        MaxHealth();
    }



    private void Update()
    {
        DeadOrAlive();
        ManaCount();
        PlayerHealth();
        ManaRegen();
    }

    private void ManaRegen()
    {
        if (mana < 300)
        {
            mana += 1 * manaRegenRate * Time.deltaTime;
        }
    }

    private void ManaCount()
    {
        if (mana >= 10)
        {
            haveMana = true;
        }
        else
        {
            haveMana = false;
        }
    }

    private void MaxHealth()
    {
        playerHealth = 1000f;
        Healthbar.SetMaxHealth(playerHealth);
    }

    void PlayerHealth()
    {

        Healthbar.SetHealth(playerHealth);

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
