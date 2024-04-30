using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    private float spawnTick = 0.5f;
    private StageData nowStage;

    private void Start()
    {
        InvokeRepeating("ObstacleSpawn", spawnTick, spawnTick);
    }

    private void ObstacleSpawn()
    {
        ObstacleKeyType randomObstacleKey = RandomObstacle()[Random.Range(0, nowStage.obstacles.Length)];
        Transform randomSpawnPoint = spawnPoints[RandomSpawnPoint()];
        
        PoolManager.Instance.Spawn(randomObstacleKey, randomSpawnPoint);
    }

    private List<ObstacleKeyType> RandomObstacle()
    {
        List<ObstacleKeyType> randomObstacle = new List<ObstacleKeyType>(nowStage.obstacles.Length); // error
        for (int i = 0; i < nowStage.obstacles.Length; i++)
        {
            randomObstacle.Add(nowStage.obstacles[i].KeyType);
        }
        return randomObstacle;
    }

    private int RandomSpawnPoint()
    {
        int randomPoint = Random.Range(0, spawnPoints.Length);
        return randomPoint;
    }

    public void SetStage(StageData stage)
    {
        nowStage = stage;
    }
}
