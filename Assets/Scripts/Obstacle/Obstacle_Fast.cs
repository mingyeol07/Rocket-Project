using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Fast : Obstacle
{
    protected override void Start()
    {
        minSpeed *= 2;
        base.Start();
    }
}
