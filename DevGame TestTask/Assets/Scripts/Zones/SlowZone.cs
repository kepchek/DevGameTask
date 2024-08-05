using UnityEngine;

public class SlowZone : MonoBehaviour
{
    public float slowFactor = 0.6f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.moveSpeed *= slowFactor;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.moveSpeed /= slowFactor;
            }
        }
    }
}
