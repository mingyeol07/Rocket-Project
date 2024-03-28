using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float initialSpeed = 10f; // 초기 우주선 속도
    public float launchAngle = 45f; // 발사 각도
    private Vector3 velocity; // 우주선의 속도 벡터

    void Start()
    {
        // 초기 속도를 발사 각도에 따라 설정
        float launchAngleRad = launchAngle * Mathf.Deg2Rad;
        float vx = initialSpeed * Mathf.Cos(launchAngleRad);
        float vy = initialSpeed * Mathf.Sin(launchAngleRad);
        velocity = new Vector3(vx, vy, 0f);
    }

    void Update()
    {
        // 운동 적용
        transform.position += velocity * Time.deltaTime;

        // 우주선의 전진 방향을 포물선 방향으로 설정
        transform.forward = velocity.normalized;

        // 중력에 의한 속도 변화 없음 (중력을 고려하지 않음)
    }
}

