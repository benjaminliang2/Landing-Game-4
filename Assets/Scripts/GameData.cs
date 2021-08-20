using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int level;
    //LevelCompleted levelCompleted;

    public GameData (LevelCompleted levelCompleted)
    {
        level = levelCompleted.level;
        //replace 3 with a dynamic variable that updates itself 
    }
    
}
