using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance; // 싱글톤

    private Dictionary<ObstacleKeyType, PoolObjectData> dataDict; // 데이터들을 저장하는 딕셔너리
    private Dictionary<ObstacleKeyType, GameObject> obstacleDict; // 데이터 안의 prefab들(원본)을  저장하는 딕셔너리
    private Dictionary<ObstacleKeyType, Stack<GameObject>> poolDict; // 풀들을 저장하는 딕셔너리
    private Dictionary<GameObject, Stack<GameObject>> clonePoolDict; // DeSpawn할때 GameObject를 찾아서 비활성화하기 위해 캐싱해두는 딕셔너리

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// 데이터리스트에서 값들을 가져와 dataDict, obstacleDict, poolDict에 각각 저장하는 함수. 스테이지매니저에서 참조
    /// </summary>
    public void Initialization(List<PoolObjectData> poolObjectDataList)
    {
        int dataLength = poolObjectDataList.Count; // 데이터종류의 갯수 (크기)

        // 갯수만큼 자리 만들어주기
        dataDict = new Dictionary<ObstacleKeyType, PoolObjectData>(dataLength);
        obstacleDict = new Dictionary<ObstacleKeyType, GameObject>(dataLength);
        poolDict = new Dictionary<ObstacleKeyType, Stack<GameObject>>(dataLength);
        clonePoolDict = new Dictionary<GameObject, Stack<GameObject>>(dataLength * PoolObjectData.INITIAL_COUNT);

        foreach (var data in poolObjectDataList)
        {
            Register(data);
        }
    }

    private void Register(PoolObjectData objectData)
    {
        if(obstacleDict.ContainsKey(objectData.KeyType)) return; // 중복 키 확인하고 있다면 return

        // prefab을 인스턴스화하다
        GameObject obstacle = Instantiate(objectData.prefab);
        obstacle.name = objectData.prefab.name;
        obstacle.transform.parent = transform;
        obstacle.SetActive(false); // 인스턴스 비활성화

        Stack<GameObject> objectPool = new Stack<GameObject>(objectData.initialCount); // 초기 생성값만큼 stack을 만들기
        for (int i =0; i < objectData.initialCount; i++) // 초기 생성값 만큼 stack안에 clone 넣기 반복
        {
            GameObject clone = Instantiate(objectData.prefab); // 가독성을 위해 clone 변수 생성
            clone.transform.parent = obstacle.transform;
            clone.SetActive(false);

            objectPool.Push(clone);
            clonePoolDict.Add(clone, objectPool);
        }

        dataDict.Add(objectData.KeyType, objectData);
        obstacleDict.Add(objectData.KeyType, obstacle);
        poolDict.Add(objectData.KeyType, objectPool);
    }

    private GameObject CloneObject(ObstacleKeyType keyType)
    {
        if (!obstacleDict.TryGetValue(keyType, out GameObject _object)) return null;
        // 키에 오브젝트가 있는지 확인
        return Instantiate(_object);
    }

    public GameObject Spawn(ObstacleKeyType keyType, Transform parent)
    {
        if (!poolDict.TryGetValue(keyType, out var pool)) return null;

        GameObject go;
        if (pool.Count > 0) // 재고 확인
        {
            go = pool.Pop(); // 꺼내서 사용
        }
        else // 없을 경우 Clone생성하고 풀에 저장
        {
            go = CloneObject(keyType);
            clonePoolDict.Add(go, pool);
        }

        go.SetActive(true);
        go.transform.SetParent(parent);
        go.transform.position = parent.position;
        go.transform.rotation = parent.rotation;

        return go;
    }

    public void DeSpawn(GameObject go)
    {
        // 캐싱된 게임오브젝트가 아닌 경우 파괴
        if (!clonePoolDict.TryGetValue(go, out var pool))
        {
            Destroy(go);
            return;
        }

        // 집어넣기
        go.SetActive(false);
        pool.Push(go);
    }
}