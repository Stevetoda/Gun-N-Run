using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFunction : MonoBehaviour
{
    [Header("Attributes")]
    public float fireRate = 1f;
    private float fireCountDown = 0f;

    [Header("Unity SetUp Fileds")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public string enemyTag = "enemy";


    //no control yet



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fireCountDown <= 0)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject tempBullet = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

    }
}
