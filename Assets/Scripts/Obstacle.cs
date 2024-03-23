using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float speed;
    private float boostSpeed;

    private void Start()
    {
        boostSpeed = speed + 20f;
    }

    private void Update()
    {
        transform.position += -transform.forward * speed * Time.deltaTime;
    }
}
