using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ListOfLevelData
{
    public List<LevelData> allLevelDataList = new List<LevelData>();

    public int i;
    public ListOfLevelData(LevelData _levelData)
    {
        //replace 0 with i later on when implementing more levels
        allLevelDataList.Add(_levelData);
        Debug.LogError("listofleveldata.cs" + allLevelDataList[0]);
    }


    //to read the first element: allLevelDataList[0]

}
