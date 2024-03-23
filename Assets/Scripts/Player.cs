using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    private bool isDragging = false;
    [SerializeField] private GameObject player = null;
    [SerializeField] private Transform center = null;
    [SerializeField] private float rotateSpeed;
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
            player.transform.DORotate(new Vector3(0, 0, 0), 1);
            Booster(true);
        }
        else
        { 
            player.transform.DORotate(new Vector3(0, 0, 0), 1);
            speed = 0;
            isDragging = false;
            Booster(false);
        }
    }


    private void TurnRight()
    {
        player.transform.DORotate(new Vector3(0, 0, -40f), 1);
    }

    private void TurnLeft()
    {
        player.transform.DORotate(new Vector3(0, 0, 40f), 1);
    }

    private void Booster(bool isBooster)
    {
        GameManager.Instance.boosting = isBooster;
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
