using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    private WaitForSeconds delay1 = new WaitForSeconds(1f);
    private WaitForSeconds delay2 = new WaitForSeconds(2f);
    private WaitForSeconds delay3 = new WaitForSeconds(3f);
    private WaitForSeconds delay5 = new WaitForSeconds(5f);

    public IEnumerator StartSpawn()
    {
        yield return null;

        int rand = Random.Range(0, 3);

        switch(rand)
        {
            case 0: 
                StartCoroutine(Spawn01());
                break;
            case 1: 
                StartCoroutine(Spawn02());
                break;
            case 2:
                StartCoroutine(Spawn03());
                break;
        }
    }

    private void Spawn()
    {
        Obstacle obstacle = SpawnManager.instance.GetObject();
        obstacle.transform.position = this.transform.position;
        obstacle.transform.parent = this.transform;
    }

    private IEnumerator Spawn01()
    {
        yield return delay3;
        Spawn();
        yield return delay2;

        StartCoroutine(StartSpawn());
    }

    private IEnumerator Spawn02()
    {
        yield return delay1;
        Spawn();
        yield return delay3;
        Spawn();
        yield return delay1;

        StartCoroutine(StartSpawn());
    }

    private IEnumerator Spawn03()
    {
        yield return delay2;
        Spawn();
        yield return delay2;
        Spawn();
        yield return delay1;
        Spawn();

        StartCoroutine(StartSpawn());
    }
}
