using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour
{

    [SerializeField] PlayerManager playerManager;


    [SerializeField] private float cooldown;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] public GameObject shootPoint1;
    [SerializeField] float animationDelay= 1f;

    public bool canshoot;



    void Start()
    {
        canshoot = true;
    }

    void Update()
    {
        PlayerShoot();
    
    }

    private void PlayerShoot()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0) && canshoot)//&& playerManager.haveMana)
        {
            StartCoroutine(ShootCoroutine(animationDelay));
        }
    }

    IEnumerator ShootCoroutine(float time)
    {
        canshoot = false;
        GetComponent<PlayerAnimation>().playerAnimator.SetTrigger("triggerShoot");
        yield return new WaitForSeconds(time);
        Instantiate(bulletPrefab, shootPoint1.transform.position, shootPoint1.transform.rotation);
        playerManager.mana -= 10;
        yield return new WaitForSeconds(fireRate);
        canshoot = true;
    }
}
