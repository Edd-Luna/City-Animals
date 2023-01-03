using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject obstacle;
    public GameObject powerup;
    public GameObject barrier;
    private float spawnRangeX = 14.0f;
    private float spawnRangeMinZ = 0.0f;
    private float spawnRangeMaxZ = 60.0f;
    private float spawnRangeXbarrier = 12.0f;
    private float obstacleSpawnY =  1.0f;
    private float powerupRangeZ = 25.0f;
    private float spawnY = 0.5f; 
    private float powerupSpawnY = 1.0f;
    private float powerupSpawnTime = 10.0f;
    private float enemySpawnTime = 2.0f;
    private float obstacleSpawnTime = 5.0f;
    private float barrierSpawnTime = 8.0f;
    private float startDelay = 1.0f;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnObstacle", startDelay, obstacleSpawnTime);
        InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
        InvokeRepeating("SpawnBarrier", startDelay, barrierSpawnTime);

    }

    void SpawnEnemy()
    {
        float randomX = Random.Range( -spawnRangeX, spawnRangeX);
        float randomZ = Random.Range( spawnRangeMinZ, spawnRangeMaxZ);
        int randomIndex = Random.Range(0, enemies.Length);

        Vector3 spawnPos = new Vector3(randomX, spawnY, randomZ);
        if(playerControllerScript.gameOver == false)
        {
        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
        }
    }

    void SpawnObstacle()
    {
        float randomX = Random.Range( -spawnRangeX, spawnRangeX);
        float randomZ = Random.Range( spawnRangeMinZ, spawnRangeMaxZ);
        Vector3 spawnPos = new Vector3(randomX, obstacleSpawnY, randomZ);
        if(playerControllerScript.gameOver == false)
        {
        Instantiate(obstacle, spawnPos, obstacle.gameObject.transform.rotation);
        }
        
    }

      void SpawnBarrier()
    {
        float randomX = Random.Range( -spawnRangeXbarrier, spawnRangeXbarrier);
        float randomZ = Random.Range( spawnRangeMinZ, spawnRangeMaxZ);
        Vector3 spawnPos = new Vector3(randomX, spawnY, randomZ);
        if(playerControllerScript.gameOver == false)
        {
        Instantiate(barrier, spawnPos, barrier.gameObject.transform.rotation);
        }
        
    }

    void SpawnPowerup()
    {
        float randomX = Random.Range( -spawnRangeX, spawnRangeX);
        float randomZ = Random.Range( -powerupRangeZ, powerupRangeZ);
        Vector3 spawnPos = new Vector3(randomX, powerupSpawnY, randomZ);
        if(playerControllerScript.gameOver == false)
        {
        Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
        }
    }
}
