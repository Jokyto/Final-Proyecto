using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CanvasManager : MonoBehaviour
{
    
    [SerializeField] GameObject camaramain;
    [SerializeField] GameObject camaraplayer;

    [SerializeField] GameObject enemyprefab;
    [SerializeField] GameObject playerPrefab;

    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject Victory;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PlayerManager>().OnPlayerDeath += EnableGameOverUI;
        FindObjectOfType<EnemyController>().OnBossDeath += EnableVictoryUI;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnableGameOverUI()
    {
        GameOver.SetActive(true);
        camaramain.SetActive(true);
        camaraplayer.SetActive(false);
        Debug.Log("UI recibio evento OnPlayerdeath de player");

    }

    public void EnableVictoryUI()
    {
        Victory.SetActive(true);
        camaramain.SetActive(true);
        camaraplayer.SetActive(false);
        Destroy(enemyprefab);
        Debug.Log("UI recibio evento OnBossdeath de Boss");
    }
}
