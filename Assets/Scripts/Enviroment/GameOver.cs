using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    PlayerMovementManager player;
    [SerializeField] GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.muerto){
           gameObject.SetActive(true);
           Destroy(playerPrefab, 5f);
        }
        else{
            gameObject.SetActive(false);
        }
    }
}
