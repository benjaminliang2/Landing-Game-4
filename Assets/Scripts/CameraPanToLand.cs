using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanToLand : MonoBehaviour
{
    Transform LandingTransform;
    Transform SpawnTransform;
    [SerializeField] float speed;
    private bool panned = false;
    Coroutine panning;
    // Start is called before the first frame update
    void Start()
    {
        panned = false;
        LandingTransform = GameObject.FindGameObjectWithTag("LandingPlatform").transform; 
        SpawnTransform = GameObject.FindGameObjectWithTag("SpawnPlatform").transform;
        transform.position = SpawnTransform.position;


    }
    void Update()
    {
        if (panned == false)
        {
            panning = StartCoroutine(CameraPanCoroutine());          
            Debug.LogError(transform.position);
        }
        if 
            (panned == true)
        {
            StopCoroutine(panning);
        }


    }

    IEnumerator CameraPanCoroutine()
    {
        Debug.Log("camerapancoroutine");
        transform.position = Vector3.MoveTowards(transform.position, LandingTransform.position, speed * Time.deltaTime);
        yield return new WaitForSeconds(20);
        Debug.Log("camerapancoroutine222");
        transform.position = Vector3.MoveTowards(transform.position, SpawnTransform.position, speed * Time.deltaTime * 1.5f);
        panned = true;
    }


}
