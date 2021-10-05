using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompleted : MonoBehaviour
{
    public delegate void CompletedLevel();
    //public static event CompletedLevel _completedLevel;
    GameObject leftHalf;
    GameObject rightHalf;
    public int level;
    private float count = 2.0f;

    //Timer - Variables
    private bool isRunning = false;
    private float startTime;
    private float timerTime;
    

    [SerializeField] Canvas LevelCompletedCanvas;
    [SerializeField] Canvas TimerCanvas;
    [SerializeField] Slider slider;

    private float startGameTime;
    private float gametime;


    void Start()
    {
        AssignGameObjects();
        DisableCanvas();
        Debug.LogError("levelcompleted start method called");
        startGameTime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        DidCompleteLevel();
    }

    private void OnDisable()
    {
        //GameManager.OnStartMenuClicked -= GoToStartMenu;
    }
    private void AssignGameObjects()
    {
        leftHalf = GameObject.FindGameObjectWithTag("PlayerLeft");
        rightHalf = GameObject.FindGameObjectWithTag("PlayerRight");
    }
    private void DidCompleteLevel()
    {
        if (leftHalf.GetComponent<LeftLanded>().leftTouch &&
            rightHalf.GetComponent<RightLanded>().rightTouch)
        {
            TimerCanvas.enabled = true;
            TimerStart();
            Timer();
            slider.value = timerTime / count;
            if (timerTime > count)
            {
                LevelCompletedCanvas.enabled = true;
                int highestLevel = 0;
                //Debug.LogError("Time Completed :" + Time.timeSinceLevelLoad);
                //this saves the highest level player has completed 
                if (SaveSystem.LoadGameData() != null)
                {
                    highestLevel = SaveSystem.LoadGameData().level;
                }
                level = SceneManager.GetActiveScene().buildIndex;

                if (level > highestLevel)
                {
                    SaveSystem.SaveGameData(this);
                }
                gametime = startGameTime - Time.time;
            }
        }
        else
        {
            TimerReset();
            TimerCanvas.enabled = false;
        }
    }

    public void NextLevel()
    {
        LevelCompletedCanvas.enabled = false;
    }

    public void DisableCanvas()
    {
        LevelCompletedCanvas.enabled = false;
        TimerCanvas.enabled = false;
    }

    private void TimerStart()
    {
        if (!isRunning)
        {
            isRunning = true;
            startTime = Time.time;
        }
    }
    private void TimerReset()
    {
        isRunning = false;
    }
    private void Timer()
    {
        timerTime = Time.time - startTime;
    }
}
