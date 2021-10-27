using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    GameObject objectToTrack;
    GameObject camTrigger;
    Vector3 tempTransform;
    public static float startGameTime;

    ListOfLevelData listofleveldata;
    void Start()
    {
        objectToTrack = GameObject.FindGameObjectWithTag("PlayerRight");
        camTrigger = GameObject.FindGameObjectWithTag("CameraTrigger");
        
    }
    private void OnEnable()
    {
        startGameTime = Time.time;
        //set z-position of camera to -200f (constant position)
        tempTransform.z = (-200f);

        //temporary code below delete later
        listofleveldata =  SaveSystem.LoadLevelDataList();
        Debug.LogError(listofleveldata.allLevelDataList[0].timeTookToComplete);

        //temporary code above delete later
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector2(objectToTrack.transform.position.x,
        //                                objectToTrack.transform.position.y);
        //Debug.LogError(transform.position);

        if (camTrigger.GetComponent<CameraTrigger>().cameraYaxisLock)
        {
            TrackX();
        }
        else
        {
            TrackY();
            TrackX();
        }

    }

    private void TrackX()
    {
        tempTransform.x = (objectToTrack.transform.position.x);
        transform.position = tempTransform;
    }

    private void TrackY()
    {
        tempTransform.y = (objectToTrack.transform.position.y);
        transform.position = tempTransform;
    }
}
