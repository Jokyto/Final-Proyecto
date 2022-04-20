using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Go_to_menu : MonoBehaviour
{
    public void Load_menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
