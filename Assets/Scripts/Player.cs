using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Runtime.CompilerServices;

public class Player : MonoBehaviour
{
    [Header("Object")]
    [SerializeField] private GameObject player = null;
    [SerializeField] private Transform center = null;

    [Header("Bool")]
    private bool isDragging = false;

    [Header("Boost")]
    [SerializeField] private float warmUpTime = 1f;
    private bool isBoost = false;

    [Header("Float")]
    [SerializeField] private float rotateSpeed = 1f;
    [SerializeField] private float rotateSize = 40f;
    private float speed;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Booster(false);
            Touch touch = Input.GetTouch(0);
            TouchPhase touchPhase = touch.phase;

            if (touchPhase == TouchPhase.Began)
            {
                isDragging = true;
            }
            else if (touchPhase == TouchPhase.Ended || touchPhase == TouchPhase.Canceled)
            {
                isDragging = false;
            }

            center.transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime * 100f));

            if (isDragging)
            {
                if (touch.position.x > Screen.width / 2)
                {
                    TurnRight();
                    speed = rotateSpeed;
                }
                else 
                {
                    TurnLeft();
                    speed = -rotateSpeed;
                }
            }
        }
        else if (Input.touchCount == 2)
        {
            player.transform.DORotate(Vector3.zero, rotateSpeed);
            if (isBoost == false) {
                StartCoroutine(StartBoost());
            }
        }
        else
        { 
            player.transform.DORotate(Vector3.zero, rotateSpeed);
            speed = 0;
            isDragging = false;
            Booster(false);
        }
    }

    private void TurnRight()
    {
        player.transform.DORotate(new Vector3(0, 0, -rotateSize), 1);
    }

    private void TurnLeft()
    {
        player.transform.DORotate(new Vector3(0, 0, rotateSize), 1);
    }

    private IEnumerator StartBoost()
    {
        float warmUpTimer = warmUpTime;
        float timer = 0f;

        while (Input.touchCount == 2 && timer < warmUpTimer)
        {
            timer += Time.unscaledDeltaTime;
            yield return null;
        }

        if (timer >= warmUpTimer)
        {
            Booster(true);
        }
    }

    private void Booster(bool isBooster)
    {
        isBoost = isBooster;
        GameManager.instance.boosting = isBoost;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle") && !GameManager.instance.isLife)
        {
            if (!isBoost)
            {
                GameManager.instance.StartCoroutine("GameOver");
                gameObject.SetActive(false);
            }
            else
            {
                other.GetComponent<Obstacle>().EscapeAnim();
            }
        }
    }
}
