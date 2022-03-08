using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int Mana;

    private void Awake()
    {
        if (instance == null)
        {
           instance = this;
           DontDestroyOnLoad(gameObject);
           Mana = 100;
         
        }else{
            Destroy(gameObject);
        }
    }

}
