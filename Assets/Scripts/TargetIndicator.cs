using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TargetIndicator : MonoBehaviour
{
    Transform Target;
    Transform PlayerTransform;
    public float HideDistance;
    public Vector3 dir;
    [SerializeField] Text DistanceText;

    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("LandingPlatform").transform;
        PlayerTransform = GameObject.FindGameObjectWithTag("PlayerLeft").transform;
        Debug.LogError("TargetIndicator --- Awake --- Finished");

    }


    /*
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        Debug.Log("targetindicator.cs OnEnable");

        Target = GameObject.FindGameObjectWithTag("LandingPlatform").transform;
        PlayerTransform = GameObject.FindGameObjectWithTag("PlayerLeft").transform;

        //dir = Target.position - PlayerTransform.position;
        Debug.LogError("TargetIndicator --- OnEnable --- Finished");

    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

        //Debug.LogError("TargetIndicator --- On Disable --- Finished");

    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Target = GameObject.FindGameObjectWithTag("LandingPlatform").transform;
        PlayerTransform = GameObject.FindGameObjectWithTag("PlayerLeft").transform;

        //Debug.LogError("TargetIndicator --- OnSceneLoaded --- Finished");

    }
    */


    //the update function shows and hides the indicator with its given conditions. 
    void Update()
    {
        dir = Target.position - PlayerTransform.position;
        if (dir.magnitude < HideDistance)
        {
            SetChildrenActive(false);
        }
        else
        {
            SetChildrenActive(true);
            DistanceText.text = dir.magnitude.ToString("#.");
        }

        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        DistanceText.rectTransform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        //Debug.LogError(Target.position + "_______" + PlayerTransform.position);
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
        var distance = Target.position - PlayerTransform.position;
        return distance.magnitude;
    }

}
