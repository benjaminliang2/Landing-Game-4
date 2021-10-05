using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    GameObject objectToTrack;
    GameObject camTrigger;
    Vector3 tempTransform;
    void Start()
    {
        objectToTrack = GameObject.FindGameObjectWithTag("PlayerRight");
        camTrigger = GameObject.FindGameObjectWithTag("CameraTrigger");
        transform.position = objectToTrack.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector2(objectToTrack.transform.position.x,
        //                                objectToTrack.transform.position.y);
        Debug.LogError(transform.position);

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
