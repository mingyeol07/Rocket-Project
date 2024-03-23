using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoint = null; // new Transform[8]
    [SerializeField] private GameObject[] Obstacles;
    [SerializeField] private float obstacleSpeed = 40f;

    private void Start()
    {
        InvokeRepeating("RandomSpawn", 0f, 0.25f);
    }

    public void RandomSpawn()
    {
        int randSpawnPoint = Random.Range(0, spawnPoint.Length);
        int randObstacle = Random.Range(0, Obstacles.Length);

        Instantiate(Obstacles[randObstacle], spawnPoint[randSpawnPoint]);
    }

    
}
