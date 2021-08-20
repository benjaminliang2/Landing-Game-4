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

    [SerializeField] Canvas LevelCompletedCanvas;

    /* private bool _completedLevel = false;

     public bool completedLevel
     {
         get
         {
             Debug.Log("GET is called");
             return _completedLevel;
         }
         set
         {
             Debug.Log("SET is called");
             _completedLevel = value;
         }
     }*/

    /*private static LevelCompleted lc_Instance = null;
    private void Awake()
    {
        if (lc_Instance == null)
        {
            lc_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }*/
    // Start is called before the first frame update
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
            LevelCompletedCanvas.enabled = true;
            //Debug.LogError("Time Completed :" + Time.timeSinceLevelLoad);
            //this saves the highest level player has completed 
            int highestLevel = SaveSystem.LoadGameData().level;
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

    public void NextLevel()
    {
        LevelCompletedCanvas.enabled = false;
    }

    public void DisableLevelCompletedCanvas()
    {
        LevelCompletedCanvas.enabled = false;
    }
}
