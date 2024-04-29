using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Move : Obstacle
{
    private Transform parent;

    void Start()
    {
        parent = GetComponentInParent<Transform>();
    }

    void Update()
    {
        
    }
}
