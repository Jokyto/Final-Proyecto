using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunLightController : MonoBehaviour
{
    // Start is called before the first frame update
[SerializeField] private float timespeed = 20f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * timespeed * Time.deltaTime);
    }
}
