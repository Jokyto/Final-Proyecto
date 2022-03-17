using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public int mana = 300;
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
