using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CanvasManager : MonoBehaviour
{
    [SerializeField] PlayerManager player;
    [SerializeField] EnemyController enemy;
    [SerializeField] GameObject canvasDeath;
    [SerializeField] GameObject canvasVictory;
    [SerializeField] GameObject camaramain;
    [SerializeField] GameObject camaraplayer;
    [SerializeField] GameObject enemyprefab;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject GameOver;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PlayerMovementManager>().OnDeath += EnableGameOverUI;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.muerto)
        {
            camaramain.SetActive(true);
            camaraplayer.SetActive(false);
            canvasDeath.SetActive(true);
            Destroy(playerPrefab);
            //Destroy(gameObject);
        }

        if (enemy.muerto)
        {
            canvasVictory.SetActive(true);
            Destroy(enemyprefab);
            // Destroy(gameObject);
        }

    }

    public void EnableGameOverUI()
    {
        GameOver.gameObject.SetActive(true);
    }
}
