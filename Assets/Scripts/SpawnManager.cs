using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoint = null; // new Transform[8]
    [SerializeField] private GameObject[] Obstacles;

    private void Start()
    {
        InvokeRepeating("RandomSpawn", 0f, 0.1f);
    }

    public void RandomSpawn()
    {
        int randNum = Random.Range(0, 10);

        if(randNum == 0)
        {
            
        }
        else if( randNum == 1) { }
        else if (randNum == 2) { }
        else if (randNum == 3) { }
        else if (randNum == 4) { }
        else if (randNum == 5) { }

        int randSpawnPoint = Random.Range(0, spawnPoint.Length);
        int randObstacle = Random.Range(0, Obstacles.Length);

        Instantiate(Obstacles[randObstacle], spawnPoint[randSpawnPoint]);
    }

    private void Pattern01()
    {
        
    }

    private void Pattern02()
    {

    }

    private void Pattern03()
    {

    }

    private void Pattern04()
    {

    }

    private void Pattern05()
    {

    }
}
