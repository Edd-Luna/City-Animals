using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject obstacle;
    public GameObject powerup;
    private float spawnRangeX = 14.0f;
    private float enemySpawnZ = 20.0f;
    private Vector3 obstacleSpawn = new Vector3 (0, 1, 30);
    private float powerupRangeZ = 15.0f;
    private float spawnY = 0.6f; 
    private float powerupSpawnTime = 10.0f;
    private float enemySpawnTime = 3.0f;
    private float obstacleSpawnTime = 10.0f;
    private float startDelay = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnObstacle", startDelay, obstacleSpawnTime);
        InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range( -spawnRangeX, spawnRangeX);
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, spawnY, enemySpawnZ);

        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
    }

    void SpawnObstacle()
    {
        Instantiate(obstacle, obstacleSpawn, obstacle.gameObject.transform.rotation);
    }

    void SpawnPowerup()
    {
        float randomX = Random.Range( -spawnRangeX, spawnRangeX);
        float randomZ = Random.Range( -powerupRangeZ, powerupRangeZ);
        Vector3 spawnPos = new Vector3(randomX, spawnY, randomZ);

        Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
    }
}
