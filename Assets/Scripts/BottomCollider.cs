using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomCollider : MonoBehaviour
{
    public bool playerDied = false;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerDied = true;
        //disable the player gameobject instead of the right half and left half of the player. 
        collision.gameObject.transform.parent.gameObject.SetActive(false);
        //Debug.Log(collision.gameObject.name);

    }
}
