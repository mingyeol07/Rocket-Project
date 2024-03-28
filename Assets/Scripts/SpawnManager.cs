using System;
using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoint = null;
    [SerializeField] private GameObject[] obstacles;

    private void Start()
    {
        RandomSpawn();
    }

    public void RandomSpawn()
    {
        int randNum = UnityEngine.Random.Range(0, 4); // 0부터 3까지의 랜덤한 숫자 생성

        if(randNum == 0)
        {
            StartCoroutine(Pattern01());
        }
        else if (randNum == 1)
        {
            StartCoroutine(Pattern01());
        }
        else if (randNum == 2)
        {
            StartCoroutine(Pattern01());
        }
        else if (randNum == 3)
        {
            StartCoroutine(Pattern01());
        }
    }

    private IEnumerator Pattern01()
    {
        int[] pattern = { 0, 1, 2, 3, 4, 5, 6, 7 };

        for (int index = 0; index < pattern.Length; index++)
        {
            InstantiateObstacle(0, pattern[index]);
            yield return new WaitForSeconds(0.1f);
        }

        RandomSpawn();
    }

    private IEnumerator Pattern02()
    {
        int[] pattern = { 0, 1, 2, 3, 4, 5, 6, 7 };

        for (int index = 0; index < pattern.Length; index++)
        {
            InstantiateObstacle(0, pattern[index]);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private IEnumerator Pattern03()
    {
        int[] pattern = { 0, 1, 2, 3, 4, 5, 6, 7 };

        for (int index = 0; index < pattern.Length; index++)
        {
            InstantiateObstacle(0, pattern[index]);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void InstantiateObstacle(int obstacleIndex, int spawnIndex)
    {
        Instantiate(obstacles[obstacleIndex], spawnPoint[spawnIndex]);
    }

}
