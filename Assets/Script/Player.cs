using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Runtime.CompilerServices;

public class Player : MonoBehaviour
{
    private Camera cam = null;
    private Vector2 startTouchPosition = Vector2.zero;
    private bool isDragging = false;
    [SerializeField] private GameObject player = null;
    [SerializeField] private float moveSpeed = 0f;

    private void Start()
    {
        cam = GameManager.Instance.mainCam;
    }

    void Update()
    {
        if (Input.touchCount == 1) // 화면에 터치가 하나만 있는 경우
        {
            Touch touch = Input.GetTouch(0);
            TouchPhase touchPhase = touch.phase;

            if (touchPhase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
                isDragging = true;
            }
            else if (touchPhase == TouchPhase.Ended || touchPhase == TouchPhase.Canceled)
            {
                isDragging = false;
            }

            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

            if (isDragging)
            {
                if (touch.position.x >= startTouchPosition.x) 
                {
                    moveSpeed = 5f;
                    TurnRight(Mathf.Abs(startTouchPosition.x - touch.position.x));
                }
                else 
                {
                    moveSpeed = -5f;
                    TurnLeft(Mathf.Abs(startTouchPosition.x - touch.position.x));
                }
            }
        }
        else if (Input.touchCount == 2)
        {
            Booster();

        }
        else
        {
            player.transform.DORotate(new Vector3(0, 0, 0), 1);
            moveSpeed = 0f;
            isDragging = false;
        }
    }

    private void TurnRight(float distance)
    {
        if(distance >= 200)
        {
            player.transform.DORotate(new Vector3(0, 0, -40f), 1);
        }
        else
        {

            player.transform.DORotate(new Vector3(0, 0, -20f), 1);
        }
    }

    private void TurnLeft(float distance)
    {
        if (distance >= 200)
        {
            player.transform.DORotate(new Vector3(0, 0, 40f), 1);
        }
        else
        {
            player.transform.DORotate(new Vector3(0, 0, 20f), 1);
        }
    }

    private void Booster()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    private void GameOver()
    {

    }
}
