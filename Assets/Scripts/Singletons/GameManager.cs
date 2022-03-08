using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score, powerupSpeed;

    private void Awake()
    {
        if (instance == null)
        {
           instance = this;
           DontDestroyOnLoad(gameObject);
           score = 0;
           powerupSpeed = 1;
        }else{
            Destroy(gameObject);
        }
    }

}
