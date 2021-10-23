using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwipeLevelSeletionMenu : MonoBehaviour
{
    public GameObject scrollBar;
    float scrollPosition = 0;
    //Array of float values. Name of array is called "position."
    float[]position;
    float distance;
    void Start()
    {
        //declare new array of float with x number of elements. X is equal to the number of children in this gameObject.
        position = new float[transform.childCount];
        distance = 1f / (position.Length - 1f);


    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0; i < position.Length; i++)
        {
            position[i] = distance * i;
        }
        if (Input.GetMouseButton(0))
        {
            scrollPosition = scrollBar.GetComponent<Scrollbar>().value;
        }
        else
        {
            //Selects closest button and auto-centers in screen when scrolling
            for (int i = 0; i < position.Length; i++)
            {
                if (scrollPosition < position[i] + (distance/2) && scrollPosition > position[i] - (distance / 2))
                {
                    scrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollBar.GetComponent<Scrollbar>().value, position[i], 0.1f);
                }
            }
        }

        //selected image is slightly enlarged. 
        for (int i = 0; i < position.Length; i++)
        {
            if (scrollPosition < position[i] + (distance / 2) && scrollPosition > position[i] - (distance / 2))
            {
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1f, 1f), 0.1f);
                for (int a = 0; a < position.Length; a++)
                {
                    if(a != i)
                    {
                        transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }

            }
        }


    }
}
