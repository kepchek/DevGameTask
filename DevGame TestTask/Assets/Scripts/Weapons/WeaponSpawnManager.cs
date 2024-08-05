using UnityEngine;

public class WeaponSpawnManager : MonoBehaviour
{
    public Weapon[] weaponPrefabs;
    public GameObject weaponPickupPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 10f;

    void Start()
    {
        InvokeRepeating("SpawnWeaponPickup", 0f, spawnInterval);
    }

    void SpawnWeaponPickup()
    {
       
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Weapon randomWeapon = weaponPrefabs[Random.Range(0, weaponPrefabs.Length)];
        
        GameObject pickup = Instantiate(weaponPickupPrefab, spawnPoint.position, spawnPoint.rotation);
        WeaponPickup weaponPickup = pickup.GetComponent<WeaponPickup>();
        weaponPickup.weaponPrefab = randomWeapon;
    }
}
