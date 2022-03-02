using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    Vector3 bulletDirection = Vector3.forward;
    [SerializeField] float bulletSpeed = 15f;
    [SerializeField] float destroyTimer = 15f;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveBullet(bulletDirection);
        destroyTimer -= Time.deltaTime;

        if (destroyTimer < 0f)
        {

            Destroy(gameObject);
        };

        //if (Input.GetKeyDown(KeyCode.Space)) { ScaleBullet(); };
    }
    void MoveBullet(Vector3 direction)
    {
        transform.Translate(direction * bulletSpeed * Time.deltaTime);
    
    }
}
    /*void ScaleBullet()
    {
        transform.localScale = new Vector3(2f, 2f, 2f);

    }
}*/
