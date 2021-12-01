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
    public int scene;
    private float count = 2.0f;

    //Timer - Variables
    private bool isRunning = false;
    private float startTime;
    private float timerTime;

    [SerializeField] Canvas LevelCompletedCanvas;
    [SerializeField] Canvas TimerCanvas;
    [SerializeField] Slider slider;

    //private float startGameTime;
    private float gametime;
    private bool completed = false;
    ListOfLevelData _ListOfLevelData;

    LevelData levelData;

    void Start()
    {
        AssignGameObjects();
        DisableCanvas();
        //Debug.LogError("levelcompleted start method called");
        //data = new LevelData();
    }

    // Update is called once per frame
    void Update()
    {
        if (completed)
        {

        }
        else
        {
            DidCompleteLevel();

        }
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

                //Debug.LogError("Time Completed :" + Time.timeSinceLevelLoad);
                //this saves the highest level player has completed 

                scene = SceneManager.GetActiveScene().buildIndex;
                gametime = Time.time - CameraTracking.startGameTime;

                if (SaveSystem.LoadLevelDataList() == null)
                {
                    levelData = new LevelData();
                    levelData.timeTookToComplete = gametime;
                    levelData.completed = true;
                    _ListOfLevelData = new ListOfLevelData();
                    _ListOfLevelData.allLevelDataList.Add(levelData);
                    SaveSystem.SaveListOfLevelData(_ListOfLevelData);
                    Debug.Log("saved list of level data");
                }

                else
                {
                    _ListOfLevelData = SaveSystem.LoadLevelDataList();
                    //check if element of that list exists. if it exists, check value of saved time and update if applicable. otherwise, create new element and add gametime as saved time. 
                    if (_ListOfLevelData.allLevelDataList.Count < (scene - 1))
                    {
                        //new data entry
                        levelData = new LevelData();
                        levelData.timeTookToComplete = gametime;
                        levelData.completed = true;
                        _ListOfLevelData.allLevelDataList.Add(levelData);
                        SaveSystem.SaveListOfLevelData(_ListOfLevelData);
                        Debug.Log("saved list of level data");

                    }
                    else //might delete else statement
                    {

                        if (gametime < _ListOfLevelData.allLevelDataList[scene - 2].timeTookToComplete)
                        {
                            _ListOfLevelData.allLevelDataList[scene - 2].timeTookToComplete = gametime;
                            SaveSystem.SaveListOfLevelData(_ListOfLevelData);
                        }
                        else
                        {
                            //do not update new gametime 
                        }

                    }

                }


                //if (level >= highestLevel)
                //{
                //    SaveSystem.SaveGameData(this);
                //    gametime = Time.time - CameraTracking.startGameTime;

                //    data.timeTookToComplete = gametime;

                //    Debug.LogError("saved timetook   " + gametime);
                //}
                //Debug.Log(gametime);
                LevelCompletedCanvas.GetComponentInChildren<Text>().text = gametime.ToString(".##");
                completed = true;
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
