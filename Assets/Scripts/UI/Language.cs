using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : MonoBehaviour
{
    [SerializeField] GameObject[] Lingua;
    [SerializeField] int lingua_scelta = 0;
    public void ProssimaLingua()
    {
        if (lingua_scelta != 2)
        {
            AbilitaLingua(lingua_scelta, false);
            lingua_scelta += 1;
            AbilitaLingua(lingua_scelta, true);
        }
        else
        {
            AbilitaLingua(lingua_scelta, false);
            lingua_scelta = 0;
            AbilitaLingua(lingua_scelta, true);
        }
    }
    void AbilitaLingua(int position, bool status)
    {
        Lingua[position].SetActive(status);
    }
}
