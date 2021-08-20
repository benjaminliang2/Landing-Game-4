using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TargetIndicator : MonoBehaviour
{
    Transform Target;
    public float HideDistance;
    public Vector3 dir;

    private void Awake()
    {
        Target = GameObject.FindGameObjectWithTag("LandingPlatform").transform;
        //Debug.LogError("TargetIndicator --- Awake --- Finished");

    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        dir = Target.position - transform.position;

        //Debug.LogError("TargetIndicator --- OnEnable --- Finished");

    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

        //Debug.LogError("TargetIndicator --- On Disable --- Finished");

    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Target = GameObject.FindGameObjectWithTag("LandingPlatform").transform;
        
        //Debug.LogError("TargetIndicator --- OnSceneLoaded --- Finished");

    }

    //the update function shows and hides the indicator with its given conditions. 
    void Update()
    {
        dir = Target.position - transform.position;
        if (dir.magnitude < HideDistance)
        {
            SetChildrenActive(false);
        }
        else
        {
            SetChildrenActive(true);
        }

        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void SetChildrenActive(bool value)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);
        }
    }

    public float GetDistanceAway()
    {
        var distance = Target.position - transform.position;
        return distance.magnitude;
    }

}
