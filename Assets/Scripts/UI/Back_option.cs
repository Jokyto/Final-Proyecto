using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Back_option : MonoBehaviour
{
    // Start is called before the first frame update
    public void Going_Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
