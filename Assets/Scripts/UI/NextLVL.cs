using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLVL : MonoBehaviour
{

    // Update is called once per frame
    public void NextLevel()
    {
        SceneManager.LoadScene("Level2");
    }
}
