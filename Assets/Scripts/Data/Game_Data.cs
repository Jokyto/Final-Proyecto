using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Language", menuName = "Create Game Language")]
public class Game_Data : ScriptableObject
{
    public GameObject[] Menu_language;
    public GameObject[] Controls_language;
    public int selected_language = 0;
}
