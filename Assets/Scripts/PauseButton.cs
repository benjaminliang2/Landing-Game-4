using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    //PauseButton should be active the entire time, same as GameManager
    //only display pause button when scene is a game level. if scene is a game level, and pause canvas is not active, then show button. if pause canvas is 
    //active, then disable button (not entire gameobject because script would then be disabled as well). 
    // Update is called once per frame

    int level;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject homeButton;
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject pauseBackground;


    void Update()
    {
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //check if buildindex is a game level
        if (scene.buildIndex > 1 || scene.buildIndex < 5)
        {
            pauseButton.SetActive(true);
            homeButton.SetActive(false);
            restartButton.SetActive(false);
            pauseBackground.SetActive(false);
        }
    }

    public void showPauseMenu()
    {
        pauseButton.SetActive(false);
        homeButton.SetActive(true);
        restartButton.SetActive(true);
        pauseBackground.SetActive(true);
    }
}
