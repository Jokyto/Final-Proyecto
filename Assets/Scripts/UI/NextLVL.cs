using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLVL : MonoBehaviour
{
    public void NextLevel()
    {
        SceneManager.LoadScene("Level2");
        this.gameObject.SetActive(false);
    }
}
