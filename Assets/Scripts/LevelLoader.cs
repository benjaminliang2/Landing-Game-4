using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevelNumber(int levelNumber)
    {


        GameManager.LoadGame();
        //if saved highest level unlocked is greater or equal to the current level selected (player tapped), then load scene
        if (GameManager.level >= levelNumber + 1 )
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
}
