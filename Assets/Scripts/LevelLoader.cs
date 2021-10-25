using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevelNumber(int levelNumber)
    {



        //TODO - Create condition that checks previous levels completion

        //load level
        SceneManager.LoadScene(levelNumber + 1);

        //TODO - create prompt that would tell player that level selected is locked and how to unlock

        Debug.LogError("Current level is locked. Complete previous levels to unlock");

    }
}
