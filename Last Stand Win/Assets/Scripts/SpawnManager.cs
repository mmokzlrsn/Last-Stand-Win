using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount;

    public GameObject powerUpPrefab;


    private void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            spawnEnemyWave(Random.Range(1, 4));
            spawnPowerUp();
        }
    }


    Vector3 GenerateSpawnPosition(float yPos)
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(spawnPosX, yPos, spawnPosZ);

        return spawnPos;
    }

    void spawnEnemyWave(int count)
    {
        for(int i = 0; i < count; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(transform.position.y), enemyPrefab.transform.rotation);
        }   
    }

    void spawnPowerUp()
    {
        Instantiate(powerUpPrefab, GenerateSpawnPosition(powerUpPrefab.transform.position.y), powerUpPrefab.transform.rotation);
    }
}
