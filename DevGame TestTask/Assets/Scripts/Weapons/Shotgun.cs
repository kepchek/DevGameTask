using UnityEngine;

public class Shotgun : Weapon
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1.5f; // 1.5 выстрела в секунду
    public int damage = 2;
    public int pellets = 5;
    public float spreadAngle = 10f;
    private float fireTimer = 0f;

    void Update()
    {
        fireTimer += Time.deltaTime;
    }

    public override void Shoot()
    {
        if (fireTimer >= 1f / fireRate)
        {
            fireTimer = 0f;
            Fire();
        }
    }

    private void Fire()
    {
        for (int i = 0; i < pellets; i++)
        {
            float angle = spreadAngle * (i - (pellets - 1) / 2f);
            Quaternion rotation = firePoint.rotation * Quaternion.Euler(0, angle, 0);
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.damage = damage;
        }
    }
}

