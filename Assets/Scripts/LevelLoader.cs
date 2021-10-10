using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevelNumber(int levelNumber)
    {
        SceneManager.LoadScene(levelNumber + 1);

    }
}
