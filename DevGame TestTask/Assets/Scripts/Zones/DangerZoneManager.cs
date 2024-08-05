using UnityEngine;
using System.Collections.Generic;

public class DangerZoneManager : MonoBehaviour
{
    public GameObject slowZonePrefab;
    public GameObject deathZonePrefab;
    public int slowZoneCount = 3;
    public int deathZoneCount = 2;
    public float slowZoneRadius = 3f;
    public float deathZoneRadius = 1f;
    public float mapWidth = 12f;
    public float mapHeight = 9f;
    public float minDistance = 3f;

    private List<Vector3> zonePositions = new List<Vector3>();

    void Start()
    {
        GenerateZones(slowZonePrefab, slowZoneCount, slowZoneRadius);
        GenerateZones(deathZonePrefab, deathZoneCount, deathZoneRadius);
    }

    void GenerateZones(GameObject zonePrefab, int zoneCount, float zoneRadius)
    {
        int attempts = 0;
        while (zoneCount > 0 && attempts < 1000)
        {
            Vector3 randomPosition = GetRandomPosition(zoneRadius);
            if (IsValidPosition(randomPosition, zoneRadius))
            {
                Instantiate(zonePrefab, randomPosition, Quaternion.identity);
                zonePositions.Add(randomPosition);
                zoneCount--;
            }
            attempts++;
        }
    }

    Vector3 GetRandomPosition(float radius)
    {
        float x = Random.Range(-(mapWidth / 2f - radius - minDistance), mapWidth / 2f - radius - minDistance);
        float z = Random.Range(-(mapHeight / 2f - radius - minDistance), mapHeight / 2f - radius - minDistance);
        return new Vector3(x, 0, z);
    }

    bool IsValidPosition(Vector3 position, float radius)
    {
        foreach (Vector3 existingPosition in zonePositions)
        {
            if (Vector3.Distance(position, existingPosition) < radius * 2 + minDistance)
            {
                return false;
            }
        }
        return true;
    }
}