using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{

    public bool cameraYaxisLock = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        cameraYaxisLock = true;
        //Debug.Log(cameraYaxisLock);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        cameraYaxisLock = false;
        //Debug.LogError(cameraYaxisLock);

    }
}
