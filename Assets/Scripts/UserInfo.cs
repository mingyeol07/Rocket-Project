using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    public static UserInfo Instance = null;

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this.transform); }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public int SKinID;
    public int StageID;
}
