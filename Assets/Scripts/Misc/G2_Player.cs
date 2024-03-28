using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class G2_Player : MonoBehaviour
{
    private bool isDragging = false;
    [SerializeField] private float rotateSpeed;
    private float speed;

    private void Update()
    {
        if (Input.touchCount == 1) // 화면에 터치가 하나만 있는 경우
        {
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

            transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime * 100f));

            if (isDragging)
            {
                if (touch.position.x > Screen.width / 2)
                {
                    speed = -rotateSpeed;
                }
                else
                {
                    speed = rotateSpeed;
                }
            }
        }
        else if (Input.touchCount == 2)
        {
            
        }
        else
        {
            speed = 0f;
            isDragging = false;
        }
    }
}
