using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject fastEnemyPrefab;
    public GameObject armoredEnemyPrefab;

    public float spawnInterval = 2f;
    public float spawnIntervalReduction = 0.1f;
    public float minimumSpawnInterval = 0.5f;

    public float mapWidth = 12f;
    public float mapHeight = 9f;
    private float timeElapsed = 0f;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);

            timeElapsed += spawnInterval;
            if (timeElapsed >= 10f)
            {
                timeElapsed = 0f;
                spawnInterval = Mathf.Max(minimumSpawnInterval, spawnInterval - spawnIntervalReduction);
            }
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        GameObject enemyPrefab = GetRandomEnemyPrefab();
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    Vector3 GetRandomSpawnPosition()
    {
        float x = 0f, z = 0f;
        int side = Random.Range(0, 4); // 0 - left, 1 - right, 2 - top, 3 - bottom

        switch (side)
        {
            case 0: // left
                x = -mapWidth / 2f - 1f;
                z = Random.Range(-mapHeight / 2f, mapHeight / 2f);
                break;
            case 1: // right
                x = mapWidth / 2f + 1f;
                z = Random.Range(-mapHeight / 2f, mapHeight / 2f);
                break;
            case 2: // top
                x = Random.Range(-mapWidth / 2f, mapWidth / 2f);
                z = mapHeight / 2f + 1f;
                break;
            case 3: // bottom
                x = Random.Range(-mapWidth / 2f, mapWidth / 2f);
                z = -mapHeight / 2f - 1f;
                break;
        }

        return new Vector3(x, 1.05f, z);
    }

    GameObject GetRandomEnemyPrefab()
    {
        float randomValue = Random.Range(0f, 100f);

        if (randomValue < 60f)
        {
            return enemyPrefab; // Рядовой
        }
        else if (randomValue < 90f)
        {
            return fastEnemyPrefab; // Шустрый
        }
        else
        {
            return armoredEnemyPrefab; // Бронированный
        }
    }
}
