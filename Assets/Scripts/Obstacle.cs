using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float minSpeed;
    private float speed;

    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        speed = Mathf.Clamp(speed, minSpeed, 100f);
        transform.position += -transform.forward * speed * Time.deltaTime;
    }
}
