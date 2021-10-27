using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class LevelData
{
    public float timeTookToComplete;

    public LevelData(float time)
    {
        timeTookToComplete = time;
    }
}

