using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoint = null;
    [SerializeField] private GameObject[] obstacles;

    private int pattern01Int = 4;
    private int[] patternTick = { 0, 1, 2, 3, 4, 5, 6, 7 };

    private WaitForSeconds spawnTick01 = new WaitForSeconds(0.1f);
    private WaitForSeconds spawnTick02 = new WaitForSeconds(0.2f);
    private WaitForSeconds spawnTick05 = new WaitForSeconds(0.5f);

    public IEnumerator RandomSpawn()
    {
        if (GameManager.instance.isGame == false) yield break;
        yield return spawnTick05;

        int randNum = UnityEngine.Random.Range(0, 4);

        if(randNum == 0)
        {
            StartCoroutine(Pattern01());
        }
        else if (randNum == 1)
        {
            StartCoroutine(Pattern02());
        }
        else if (randNum == 2)
        {
            StartCoroutine(Pattern03());
        }
        else if (randNum == 3)
        {
            StartCoroutine(Pattern02());
        }
    }

    private IEnumerator Pattern01()
    {
        for (int index = 0; index < patternTick.Length; index++)
        {
            InstantiateObstacle(UnityEngine.Random.Range(0, obstacles.Length), patternTick[index]);
            InstantiateObstacle(UnityEngine.Random.Range(0, obstacles.Length),
                    (index >= pattern01Int) ? patternTick[index - pattern01Int] : patternTick[index + pattern01Int]);
            yield return spawnTick02;
        }
        StartCoroutine(RandomSpawn());
    }

    private IEnumerator Pattern02()
    {
        for (int index = 0; index < patternTick.Length; index++)
        {
            if(index % 2 == 0)
            {
                InstantiateObstacle(UnityEngine.Random.Range(0, obstacles.Length), patternTick[index]);
                InstantiateObstacle(UnityEngine.Random.Range(0, obstacles.Length), patternTick[index + 1]);
                InstantiateObstacle(UnityEngine.Random.Range(0, obstacles.Length),
                    (index >= 4) ? patternTick[index - 4] : patternTick[index + 4]);
                InstantiateObstacle(UnityEngine.Random.Range(0, obstacles.Length),
                    (index >= 4) ? patternTick[index + 1 - 4] : patternTick[index + 1 + 4]);
            }
            
            yield return spawnTick02;
        }
        StartCoroutine(RandomSpawn());
    }

    private IEnumerator Pattern03()
    {
        for (int index = 0; index < patternTick.Length; index++)
        {
            if (index % 2 == 0)
            {

            } 
            yield return spawnTick02;
        }
        StartCoroutine(RandomSpawn());
    }

    private void InstantiateObstacle(int obstacleIndex, int spawnIndex)
    {
        Instantiate(obstacles[obstacleIndex], spawnPoint[spawnIndex]);
    }

}
