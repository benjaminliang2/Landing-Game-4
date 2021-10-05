using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelFailed : MonoBehaviour
{

    [SerializeField] Canvas LevelFailedCanvas;
    float outOfBoundsDistance = 200;

    [SerializeField] GameObject bottomBoundary;
    CheckJoint checkJoint;
    TargetIndicator _targetIndicator;
    BottomCollider bottomCollider;


    void Start()
    {
        //DontDestroyOnLoad(this);
        AssignGameObjects();
        DisableLevelFailedCanvas();

    }

    void Update()
    {
        didFlyTooFar();
        didJointBreak();
        didCollideWithBottom();
    }

    private void didCollideWithBottom()
    {
        if(bottomCollider.playerDied == true)
        {
            LevelFailedCanvas.enabled = true;

        }
    }

    void AssignGameObjects()
    {
        checkJoint = FindObjectOfType<CheckJoint>();
        _targetIndicator = FindObjectOfType<TargetIndicator>();
        bottomCollider = FindObjectOfType<BottomCollider>();
        //Debug.LogError("LevelFailed --- AssignGameObject --- Finished");

    }

    public void didJointBreak()
    {
        if (checkJoint.jointBroke)
        {
            LevelFailedCanvas.enabled = true;
        }
    }

    public void didFlyTooFar()
    {
        if (_targetIndicator.GetDistanceAway() > outOfBoundsDistance)
        {
            LevelFailedCanvas.enabled = true;
            //Debug.LogError("LevelFailed --- DidFlyTooFar");
            //Debug.LogError(_targetIndicator.GetDistanceAway() + "...." + outOfBoundsDistance);
        }
    }

    public void DisableLevelFailedCanvas()
    {
        LevelFailedCanvas.enabled = false;
        //Debug.LogError("LevelFailed --- DiabledLevelFailedCanvas --- Finished");

    }

}
