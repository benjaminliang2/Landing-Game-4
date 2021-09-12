using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelFailed : MonoBehaviour
{

    [SerializeField] Canvas LevelFailedCanvas;
    float outOfBoundsDistance = 200;

    CheckJoint checkJoint;
    TargetIndicator _targetIndicator;
    /*private static LevelFailed lf_Instance = null;
    private void Awake()
    {
        if (lf_Instance == null)
        {
            lf_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }*/


    void Start()
    {
        //DontDestroyOnLoad(this);
        AssignGameObjects();
        DisableLevelFailedCanvas();
        Debug.LogError("LevelFailed --- Start --- EndofStartMethod");

    }

    void Update()
    {
        didFlyTooFar();
        didJointBreak();
    }
    void AssignGameObjects()
    {
        checkJoint = FindObjectOfType<CheckJoint>();
        _targetIndicator = FindObjectOfType<TargetIndicator>();
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
