using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletPrefab;
    public PlayerMove player;
    public bool achievementAim = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && player.IsAttacking == 0 && player.isGrounded == true && achievementAim == true) {
            Shoot();
        }
    }

    void Shoot()
    {
        player.IsAttacking = 1;
        Invoke("CreateBullet", 0.2f);
    }

    void CreateBullet()
    {
        Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
    }
}
