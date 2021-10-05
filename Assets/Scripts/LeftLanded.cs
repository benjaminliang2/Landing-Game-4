using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftLanded : MonoBehaviour
{
    public bool leftTouch = false;
    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LandingPlatform"))
        {
            leftTouch = true;
        }

    }
    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("LandingPlatform"))
        {
            leftTouch = false;
        }
    }

}
