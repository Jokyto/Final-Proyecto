using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Last_totem : MonoBehaviour
{
    [SerializeField] GameObject water_totem;

    // Update is called once per frame
    void Update()
    {
        if (!water_totem && !GameManager.instance.totems_destroyed)
        {
            GameManager.instance.last_sp = 2;
        }
        if (GameManager.instance.totems_destroyed)
        {
            Destroy(gameObject);
        }
    }
}
