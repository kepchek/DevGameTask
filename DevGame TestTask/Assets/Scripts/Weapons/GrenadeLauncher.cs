using UnityEngine;

public class GrenadeLauncher : Weapon
{
    public GameObject grenadePrefab;
    public Transform firePoint;
    public float fireRate = 0.66f; // 0.66 выстрела в секунду
    public int damage = 10;
    public float explosionRadius = 2f;
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
        GameObject grenade = Instantiate(grenadePrefab, firePoint.position, firePoint.rotation);
        Grenade grenadeScript = grenade.GetComponent<Grenade>();
        grenadeScript.damage = damage;
        grenadeScript.radius = explosionRadius;

        // Получить позицию мыши
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            grenadeScript.target = hit.point;
        }
    }
}
