using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.PostProcessing;
using UnityEngine;

public class Obstacle_Slow : Obstacle
{
    protected override void Start()
    {
        minSpeed /= 2;
        base.Start();
    }
}
