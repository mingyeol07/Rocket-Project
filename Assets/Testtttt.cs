using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testtttt : MonoBehaviour
{
    public float rotationSpeed = 50.0f; // 회전 속도
    public float radius = 5.0f; // 원의 반지름

    private float angle = 0f; // 현재 각도
    [SerializeField] private Transform position;

    void Update()
    {
        // 시간에 따라 각도를 증가시킵니다.
        angle += rotationSpeed * Time.deltaTime;

        // 각도를 라디안으로 변환합니다.
        float radian = angle * Mathf.Deg2Rad;

        // 새 위치를 계산합니다. z 위치는 변경하지 않습니다.
        Vector3 newPosition = new Vector3(Mathf.Cos(radian) * radius, Mathf.Sin(radian) * radius, 0);

        // 객체를 새 위치로 이동시킵니다.
        transform.position = position.position + newPosition;
    }
}
