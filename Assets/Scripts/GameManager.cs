using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public delegate void StartMenuClicked();
    //public static event StartMenuClicked OnStartMenuClicked;

    public int level;
    [SerializeField] GameObject player;
    [SerializeField] GameObject levelFailed;
    [SerializeField] GameObject levelCompleted;
    [SerializeField] GameObject startMenu;
    [SerializeField] Camera cameraPrefab;
    [SerializeField] GameObject backgroundPrefab;
    [SerializeField] Canvas startMenuCanvas;
    //[SerializeField] CameraPanToLand cameraPanToLand;

    private static GameManager gm_Instance = null;
    //public static int prevSceneNumber;
    //public static int currentSceneNumber;

    private void Awake()
    {
        if (gm_Instance == null)
        {
            gm_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Debug.LogError("GameManager Destroyed");
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        Debug.Log("gamemanager onenable");
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        Debug.Log("gamemanager onDISABLE");

    }

    public void SaveGame(LevelCompleted levelData)
    {        
        SaveSystem.SaveGameData(levelData);
    }
    public void LoadGame()
    {
        GameData data = SaveSystem.LoadGameData();

        if (data != null)
        {
            level = data.level + 1;
            //Debug.LogError("level data loaded successfully");
        }
        else
        {
            level = 2;
        }
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }

    public void DeleteGame()
    {
        SaveSystem.DeleteGameData();
    }

    //I need to assign GoToStartMenu() to a button click so that it triggers the 
    //StartMenuClicked delegate. 
    public void GoToStartMenu()
    {
        //OnStartMenuClicked();
        SceneManager.LoadScene("Start Menu", LoadSceneMode.Single);
    }
    public void GoToLevelSelectionMenu()
    {
        //OnStartMenuClicked();
        SceneManager.LoadScene("Level Selector Menu", LoadSceneMode.Single);
    }

    public void GoToNextLevel()
    {     
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);

    }
    

    //this will determine which gameobjects are active depending on which scene is currently loaded.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("gamemanager.onsceneloaded");
        if (scene.name.Contains("Start Menu") || scene.name.Contains("Level Selector Menu"))
        {
            //Instantiate(startMenu, transform.position, Quaternion.identity);
            //Debug.Log("gamemanager.onsceneloaded.startmenu _ detected");
        }
        else
        {
            //camera needs to spawn in view of spawn platform.
            Instantiate(cameraPrefab, transform.position, Quaternion.identity);           

            //Player instantiation location doesnt matter because player script will relocate it anyway.
            Instantiate(player, transform.position, Quaternion.identity);            
            Instantiate(levelFailed, transform.position, Quaternion.identity);
            Instantiate(levelCompleted, transform.position, Quaternion.identity);
        }
    }
}
