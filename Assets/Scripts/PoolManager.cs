using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance; // �̱���

    private Dictionary<ObstacleKeyType, PoolObjectData> dataDict; // �����͵��� �����ϴ� ��ųʸ�
    private Dictionary<ObstacleKeyType, GameObject> obstacleDict; // ������ ���� prefab��(����)��  �����ϴ� ��ųʸ�
    private Dictionary<ObstacleKeyType, Stack<GameObject>> poolDict; // Ǯ���� �����ϴ� ��ųʸ�
    private Dictionary<GameObject, Stack<GameObject>> clonePoolDict; // DeSpawn�Ҷ� GameObject�� ã�Ƽ� ��Ȱ��ȭ�ϱ� ���� ĳ���صδ� ��ųʸ�

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// �����͸���Ʈ���� ������ ������ dataDict, obstacleDict, poolDict�� ���� �����ϴ� �Լ�. ���������Ŵ������� ����
    /// </summary>
    public void Initialization(List<PoolObjectData> poolObjectDataList)
    {
        int dataLength = poolObjectDataList.Count; // ������������ ���� (ũ��)

        // ������ŭ �ڸ� ������ֱ�
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
        if(obstacleDict.ContainsKey(objectData.KeyType)) return; // �ߺ� Ű Ȯ���ϰ� �ִٸ� return

        // prefab�� �ν��Ͻ�ȭ�ϴ�
        GameObject obstacle = Instantiate(objectData.prefab);
        obstacle.name = objectData.prefab.name;
        obstacle.transform.parent = transform;
        obstacle.SetActive(false); // �ν��Ͻ� ��Ȱ��ȭ

        Stack<GameObject> objectPool = new Stack<GameObject>(objectData.initialCount); // �ʱ� ��������ŭ stack�� �����
        for (int i =0; i < objectData.initialCount; i++) // �ʱ� ������ ��ŭ stack�ȿ� clone �ֱ� �ݺ�
        {
            GameObject clone = Instantiate(objectData.prefab); // �������� ���� clone ���� ����
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
        // Ű�� ������Ʈ�� �ִ��� Ȯ��
        return Instantiate(_object);
    }

    public GameObject Spawn(ObstacleKeyType keyType, Transform parent)
    {
        if (!poolDict.TryGetValue(keyType, out var pool)) return null;

        GameObject go;
        if (pool.Count > 0) // ��� Ȯ��
        {
            go = pool.Pop(); // ������ ���
        }
        else // ���� ��� Clone�����ϰ� Ǯ�� ����
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
        // ĳ�̵� ���ӿ�����Ʈ�� �ƴ� ��� �ı�
        if (!clonePoolDict.TryGetValue(go, out var pool))
        {
            Destroy(go);
            return;
        }

        // ����ֱ�
        go.SetActive(false);
        pool.Push(go);
    }
}