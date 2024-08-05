using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public Weapon weaponPrefab;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.ChangeWeapon(weaponPrefab);
                Destroy(gameObject); // Удалить бонус после подбора
            }
        }
    }
}
