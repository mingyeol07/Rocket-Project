using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float minSpeed;
    [SerializeField] private int destroyWaitTime;
    private float speed;

    private void Start()
    {
        StartCoroutine(Reset());
        speed = Mathf.Clamp(speed, minSpeed, 100f);
    }

    private void Update()
    {
        transform.position += -transform.forward * speed * Time.deltaTime;
    }

    public void EscapeAnim()
    {
        float deg = Random.Range(0, 180);
        transform.eulerAngles = new Vector3(deg, 90, transform.rotation.z);
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(destroyWaitTime);
        PoolManager.Instance.DeSpawn(gameObject);
    }
}
