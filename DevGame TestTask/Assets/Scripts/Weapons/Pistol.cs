using UnityEngine;

public class Pistol : Weapon
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2f; // 2 выстрела в секунду
    public int damage = 3;
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
