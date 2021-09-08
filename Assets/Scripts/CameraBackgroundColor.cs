using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraBackgroundColor : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        //Camera cam = GetComponent<Camera>();
        switch (level)
        {
            case 0:
            case 1:
            case 2:
            case 3:

                Camera.main.backgroundColor = Color.black;
                break;
        }
    }
}
