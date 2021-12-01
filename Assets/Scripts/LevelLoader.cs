using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int listCount;
    public ListOfLevelData listOfLevelData;
    LevelData emptyData;
    public void LoadLevelNumber(int levelNumber)
    {
        listCount = listOfLevelData.allLevelDataList.Count;

        if(listCount != 0)
        {
            //if saved highest level unlocked is greater or equal to the current level selected (player tapped), then load scene
            if (listOfLevelData.allLevelDataList[levelNumber - 1].completed == true)
            {
                //load level
                SceneManager.LoadScene(levelNumber + 1);

            }
            else
            {
                //TODO - create prompt that would tell player that level selected is locked and how to unlock
                Debug.LogError(GameManager.level + "......." + levelNumber);
                Debug.LogError("Current level is locked. Complete previous levels to unlock");
            }
        }
        else
        {
            emptyData = new LevelData();
            emptyData.timeTookToComplete = 1000f;
            emptyData.completed = true;
            listOfLevelData.allLevelDataList.Add(emptyData);
            SceneManager.LoadScene(levelNumber + 1);

        }



    }
}
