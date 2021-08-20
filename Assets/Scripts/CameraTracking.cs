using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    [SerializeField] GameObject objectToTrack;
    void Start()
    {
        transform.position = objectToTrack.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (objectToTrack.transform.position.x,
                                          objectToTrack.transform.position.y,
                                          -10f);
        
    }
}
