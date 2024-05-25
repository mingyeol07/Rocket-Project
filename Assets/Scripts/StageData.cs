using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StageData
{
    public string stageName;

    public PoolObjectData[] obstacles;
    public Material backGround;
    public Material CylinderMaterial;
    public Material CylinderInsideMaterial;
}