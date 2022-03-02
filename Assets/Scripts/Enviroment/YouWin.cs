using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouWin : MonoBehaviour
{
    EnemyController enemy;
    [SerializeField] GameObject enemyprefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemy.muerto)
        {
           gameObject.SetActive(true);
           Destroy(enemyprefab);
        }
        else{
            gameObject.SetActive(false);
        }
    }
}
