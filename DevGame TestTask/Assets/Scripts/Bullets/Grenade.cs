using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10;
    public float radius = 2f;
    public Vector3 target;

    private void Update()
    {
        // Движение снаряда к цели
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        // Взрыв при достижении цели
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            Explode();
        }
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.CompareTag("Enemy"))
            {
                Enemy enemy = nearbyObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }
        }
        Destroy(gameObject);
    }
}
