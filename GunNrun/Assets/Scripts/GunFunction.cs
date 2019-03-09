using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunFunction : MonoBehaviour
{
    [Header("Attributes")]
    public float fireRate = 1f;
    public float reloadSpeed = 1.5f;
    public int regularMagazine = 20;
    public int specialMagazine = 2;

    [Header("Unity SetUp Fileds")]
    public GameObject bulletPrefab;
    public GameObject speicalBulletPrefab;
    public Transform firePoint;
    public string enemyTag = "enemy";

    [Header("Display")]
    public Text regBulletCount;
    public Text specBulletCount;

    [Header("HotKeys")]
    public string shootKey = "s";
    public string specialShoot = "f";
    public string regularReloadKey = "r";


    private float fireCountDown = 0f;
    private int currentRegularBulletCount;
    private int currentSpecialBluuetCount;



    // Start is called before the first frame update
    void Start()
    {
        currentRegularBulletCount = regularMagazine;
        currentSpecialBluuetCount = specialMagazine;
        UpdateRegBulletCount();
        UpdateSpecBulletCount();
    }

    // Update is called once per frame
    void Update()
    {

        if(fireCountDown > 0)
        {
            fireCountDown -= Time.deltaTime;
        }
        else
        {

            if (Input.GetKey(shootKey) && currentRegularBulletCount > 0)
            {
                Shoot();
            }else if (Input.GetKey(specialShoot) && currentSpecialBluuetCount > 0)
            {
                ShootSpecial();
            }else if (Input.GetKey(regularReloadKey))
            {
                ReloadRegularMagazine();
            }
        }


    }

    //can't shoot during reloading
    void ReloadRegularMagazine()
    {
        fireCountDown += 1f/reloadSpeed;
        currentRegularBulletCount = regularMagazine;
        UpdateRegBulletCount();
    }

    void Shoot()
    {
        currentRegularBulletCount -= 1;
        UpdateRegBulletCount();
        fireCountDown = 1f / fireRate;
        GameObject tempBullet = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }


    //shoot special bullet
    void ShootSpecial()
    {
        currentSpecialBluuetCount -= 1;
        UpdateSpecBulletCount();
        fireCountDown = 1f / fireRate;
        GameObject tempBullet = (GameObject)Instantiate(speicalBulletPrefab, firePoint.position, firePoint.rotation);
    }

    public int GetRegularBulletCount()
    {
        return currentRegularBulletCount;
    }

    public int GetSpeicalBulletCount()
    {
        return currentSpecialBluuetCount;
    }

    //update the text
    void UpdateRegBulletCount()
    {
        regBulletCount.text = GetRegularBulletCount().ToString();
    }

    //update the text
    void UpdateSpecBulletCount()
    {
        specBulletCount.text = GetSpeicalBulletCount().ToString();
    }

}
