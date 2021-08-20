using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    // Purpose of this script is to determine when the player has died and 
    // needs to retry, or go back to the main menu. 

    [SerializeField] float outOfBoundsDistance;
    CheckJoint checkJoint;
    TargetIndicator _targetIndicator;
   // [SerializeField] Canvas PlayerDiedCanvas;


    private void Awake()
    {
        int numberGameOver = FindObjectsOfType<GameOver>().Length;
        if (numberGameOver > 1)
        {
            Debug.LogError("destroyed gameover GO");
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Debug.LogError(" DO NOTTT destroyed gameover GO");

        }
    }

    private void Start()
    {
        AssignGameObjects();
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AssignGameObjects();
        Debug.LogError("gameover function onsceneloaded");
    }
    void AssignGameObjects()
    {
        checkJoint = FindObjectOfType<CheckJoint>();
        _targetIndicator = FindObjectOfType<TargetIndicator>();
    }

    // Update is called once per frame
    void Update()
    {
        didJointBreak();
        didFlyTooFar();
    }

    public bool didJointBreak()
    {
        if (checkJoint.jointBroke)
        {
            Debug.LogError("game over because rocket broke");
            return true;
        }
        return false;
    }

    public bool didFlyTooFar()
    {
        if (_targetIndicator.dir.magnitude > outOfBoundsDistance)
        {
            return true;
        }
        return false;
    }
}
