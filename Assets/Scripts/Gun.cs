using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // When the enemies are close so the meshes collide with the Player, it gets buggy. Other than that, it seems to be working.

    // Starts with a cooldown
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float cooldown;
    [SerializeField] float speed = 10;
    private float lastShot;
    private Player playerScript;

    private void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Shoot();
        }

        // playerScript.fightingAction = Shoot;
    }

    private void Shoot()
    {
        if (Time.time - lastShot < cooldown)
        {
            return;
        }
        lastShot = Time.time;
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = firePoint.forward * speed; 
    }
}
