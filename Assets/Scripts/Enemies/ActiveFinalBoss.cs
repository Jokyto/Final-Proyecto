using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveFinalBoss : MonoBehaviour
{

    [SerializeField] GameObject finalBoss;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<DestroyFinalRune>().onFinalRuneDestroyed += ActiveBoss;
    }

    private void ActiveBoss()
    {
        StartCoroutine("BossActivationCoroutine");
    }

    IEnumerator BossActivationCoroutine()
    {
        Debug.Log("FinalBossActivado");
        yield return new WaitForSeconds(1);
        finalBoss.SetActive(true);
    }
}
