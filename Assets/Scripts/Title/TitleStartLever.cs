using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TitleStartLever : MonoBehaviour
{
    [SerializeField] private Transform startLever_rotation;
    private Vector2 startFingerPos;
    private float distance;
    private bool isFingerDown;

    private void OnMouseDown()
    {
        isFingerDown = true;
        startFingerPos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        if(isFingerDown)
        {
            if(distance >= 500)
            {
                TitleManager.Instance.OnGameStartLever();
            }
            else
            {
                distance = Mathf.Clamp(Mathf.Abs(startFingerPos.y - Input.mousePosition.y), 0, 500);
                startLever_rotation.localRotation = Quaternion.Euler(((distance / 500) * 180) - 266, 0, 0);
            }
        }
    }

    private void OnMouseUp()
    {
        isFingerDown = false;
        distance = 0;
        startLever_rotation.transform.DOLocalRotate(new Vector3(-266, 0, 0), 0.5f);
    }
}