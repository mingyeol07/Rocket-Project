using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    [SerializeField] private Transform[] spawnPoint = null;
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private SpawnObstacle[] spawnObstacles = null;
    [SerializeField] private Queue<Obstacle> obstaclePoolObject = new Queue<Obstacle>();

    private int pattern01Int = 4;
    private int[] patternTick = { 0, 1, 2, 3, 4, 5, 6, 7 };

    private WaitForSeconds spawnTick01 = new WaitForSeconds(0.1f);
    private WaitForSeconds spawnTick02 = new WaitForSeconds(0.2f);
    private WaitForSeconds spawnTick05 = new WaitForSeconds(0.5f);

    private void Awake()
    {
        instance = this;

        Initialize(100);
    }

    public void Initialize(int count)
    {
        // Queue에 값을 넣을 땐 Enqueue
        // Queue에 값을 뺄 땐 DeQueue
        for (int i = 0; i < count; i++)
        {
            obstaclePoolObject.Enqueue(CreateObjtct());
        }
    }

    public Obstacle GetObject()
    {
        Obstacle obstacle = null;

        if (obstaclePoolObject.Count <= 0)
            obstacle = CreateObjtct();
        else
            obstacle = obstaclePoolObject.Dequeue();

        // 오브젝트를 활성화상태로 바꿔주기
        obstacle.gameObject.SetActive(true);

        // 오브젝트를 내 자식에서 해제해주기
        obstacle.transform.SetParent(null);

        return obstacle;
    }

    private Obstacle CreateObjtct()
    {
        Obstacle obstacle = GameObject.Instantiate(obstacles[UnityEngine.Random.Range(0, obstacles.Length)]).GetComponent<Obstacle>();

        // 오브젝트를 비활성화된 상태로 만들기
        obstacle.gameObject.SetActive(false);

        // 생성된 오브젝트를 나의 자식 오브젝트들로 만들기
        obstacle.transform.SetParent(this.transform);

        return obstacle;
    }

    public void ResetForPool(Obstacle obstacle)
    {
        // 오브젝트를 비활성화 시키기
        obstacle.gameObject.SetActive(false);
        // 오브젝트를 내 자식으로 만들기
        obstacle.transform.SetParent(this.transform);
        // 큐에 저장
        obstaclePoolObject.Enqueue(obstacle);
    }

    // GameManager에서 게임스타트할 때 실행
    public IEnumerator RandomSpawn()
    {
        if (GameManager.instance.isGame == false) yield break;
        yield return spawnTick05;

        for (int i = 0; i< spawnPoint.Length; i++)
        {
            spawnObstacles[i].StartCoroutine("StartSpawn");
        }

        /*
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
        } */
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
