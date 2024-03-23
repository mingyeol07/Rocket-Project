using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        transform.position += -transform.forward * speed * Time.deltaTime;
    }

    public void SetSpeed(float ChangeSpeed)
    {
        speed = ChangeSpeed;
    }
}
