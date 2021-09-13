using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    GameObject objectToTrack;
    void Start()
    {
        objectToTrack = GameObject.FindGameObjectWithTag("PlayerRight");
        transform.position = objectToTrack.transform.position;
        //Debug.Log("camera tracking . awake");
        Debug.Log( transform.position + "_____" + objectToTrack.transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2 (objectToTrack.transform.position.x,
                                          objectToTrack.transform.position.y);        
    }
}
