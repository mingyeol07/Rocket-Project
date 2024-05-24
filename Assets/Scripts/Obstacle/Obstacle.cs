using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] protected float minSpeed;
    [SerializeField] private int destroyWaitTime;
    private float speed;

    protected virtual void Start()
    {
        StartCoroutine(Despawn());
        speed = Mathf.Clamp(speed, minSpeed, 100f);
    }

    protected virtual void Update()
    {
        transform.position += -transform.forward * speed * Time.deltaTime;
    }

    public virtual void EscapeAnim()
    {
        float deg = Random.Range(0, 180);
        transform.eulerAngles = new Vector3(deg, 90, transform.rotation.z);
    }

    private IEnumerator Despawn()
    {
        yield return new WaitForSeconds(destroyWaitTime);
        PoolManager.Instance.DeSpawn(gameObject);
    }
}
