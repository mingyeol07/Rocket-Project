using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Move : Obstacle
{
    [SerializeField] private Transform child;
    private int randomRotateVec;
    [SerializeField] private float rotateSpeed;

    protected override void Start()
    {
        base.Start();
        randomRotateVec = (int)Mathf.Sign((float)Random.Range(-1, 1));
        child = GetComponentInChildren<Transform>();
        
    }

    protected override void Update()
    {
        base.Update();
        transform.position = new Vector3(0, 0, transform.position.z);
        child.eulerAngles += new Vector3(0, 0, randomRotateVec * rotateSpeed);
    }
}
