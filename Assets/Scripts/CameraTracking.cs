using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    GameObject objectToTrack;
    void OnEnable()
    {
        objectToTrack = GameObject.FindGameObjectWithTag("PlayerLeft");
        //transform.position = objectToTrack.transform.position;        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2 (objectToTrack.transform.position.x,
                                          objectToTrack.transform.position.y);        
    }
}
