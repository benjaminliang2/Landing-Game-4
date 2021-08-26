using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleted : MonoBehaviour
{
    public delegate void CompletedLevel();
    public static event CompletedLevel _completedLevel;
    GameObject leftHalf;
    GameObject rightHalf;
    public int level;

    //Timer - Variables
    private bool isRunning = false;
    private float startTime;
    private float timerTime;
    

    [SerializeField] Canvas LevelCompletedCanvas;

    void Start()
    {
        AssignGameObjects();
        DisableLevelCompletedCanvas();
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
            TimerStart();
            Timer();
            if (timerTime > 2.0)
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
                //_completedLevel();
                //i can have some cod ein game manager that disables the level completed GO until
                //a new level is loaded. reason why is because i dont w
            }
        }
        else
        {
            TimerReset();
        }
    }

    public void NextLevel()
    {
        LevelCompletedCanvas.enabled = false;
    }

    public void DisableLevelCompletedCanvas()
    {
        LevelCompletedCanvas.enabled = false;
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
