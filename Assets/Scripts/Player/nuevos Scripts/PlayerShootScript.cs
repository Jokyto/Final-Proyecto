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

    public bool canshoot;
    


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerShoot();
        PlayerCooldown();
    }
    private void PlayerCooldown()
    {
        if (!canshoot)
        {

            cooldown -= Time.deltaTime * fireRate;

            if (cooldown <= 0f)
            {
                canshoot = true;
            }

        };
    }

    private void PlayerShoot()
    {

        

        if (Input.GetKeyDown(KeyCode.Mouse0) && canshoot && playerManager.haveMana)
        {
            // playerAnimator.SetBool("isCasting", true);
        };

        if (Input.GetKeyUp(KeyCode.Mouse0) && canshoot && playerManager.haveMana)
        {
            Instantiate(bulletPrefab, shootPoint1.transform.position, shootPoint1.transform.rotation);
            canshoot = false;
            cooldown = 2f;
            playerManager.mana -=10;
        }
    }
}
