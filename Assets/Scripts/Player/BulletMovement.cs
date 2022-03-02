using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rbBullet;
    [SerializeField] private float castForce = 3;
    [SerializeField] float destroyTimer = 3f;



    void Start()
    {
        rbBullet = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        BulletImpulse();
        DestroyTimer();
    }

    private void BulletImpulse()
    {

        rbBullet.AddRelativeForce(Vector3.forward * castForce, ForceMode.Impulse);

    }

    private void DestroyTimer()
    {
        destroyTimer -= Time.deltaTime;
        if (destroyTimer < 0f)
        {

            Destroy(gameObject);
        };
    }
    private void OnCollisionEnter(Collision other)
    {
        
        
            Destroy(gameObject);
        
    }
}
