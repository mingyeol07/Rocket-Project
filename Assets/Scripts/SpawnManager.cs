using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private StageData nowStage;

    public void SetStage(StageData stage)
    {
        nowStage = stage;
    }
}
