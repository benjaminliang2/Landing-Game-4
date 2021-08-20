using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLanded : MonoBehaviour
{
    public bool rightTouch = false;

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("LandingPlatform"))
        {
            rightTouch = true;
        }
    }
    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("LandingPlatform"))
        {
            rightTouch = false;
        }
    }
}
