using UnityEngine;

public class Rifle : Weapon
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 10f; // 10 выстрелов в секунду
    public int damage = 1;
    private float nextTimeToFire = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    public override void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.damage = damage;
    }
}
