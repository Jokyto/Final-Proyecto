using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_passed : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject Level_won;

    // Update is called once per frame
    void Update()
    {
        if (!Enemy)
        {
            Level_won.SetActive(true);
        }
    }
}
