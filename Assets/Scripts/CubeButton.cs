using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeButton : MonoBehaviour
{
    private Vector3 defaultScale;

    private void Start()
    {
        defaultScale = transform.localScale;
    }

    private void OnMouseDown()
    {
        transform.DOScaleZ(0.1f, 0.1f);
    }

    private void OnMouseUp()
    {
        transform.DOScaleZ(1f, 0.1f);
    }
}
