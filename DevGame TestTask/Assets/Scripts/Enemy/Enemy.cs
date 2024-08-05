using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float moveSpeed;
    public int scoreValue;

    private Transform player;
    private Rigidbody rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        ScoreManager.instance.AddScore(scoreValue);
        Destroy(gameObject);
    }
}
