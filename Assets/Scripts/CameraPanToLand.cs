using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanToLand : MonoBehaviour
{
    Transform LandingTransform;
    Transform SpawnTransform;
    [SerializeField] float speed;
    [SerializeField] float seconds;

    private bool panned = false;
    Coroutine panning;
    Player player;
    [SerializeField] GameObject targetind;

    void Start()
    {
        LandingTransform = GameObject.FindGameObjectWithTag("LandingPlatform").transform; 
        SpawnTransform = GameObject.FindGameObjectWithTag("SpawnPlatform").transform;
        //transform.position = SpawnTransform.position;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        targetind = GameObject.FindGameObjectWithTag("Target Indicator");

    }
    void Update()
    {
        if (panned == false)
        {
            panning = StartCoroutine(CameraPanCoroutine());          
        }
        if 
            (panned == true)
        {
            //StopCoroutine(panning);
            enabled = false;
        }


    }

    IEnumerator CameraPanCoroutine()
    {
        player.enabled = false;
        gameObject.GetComponent<CameraTracking>().enabled = false;
        targetind.SetActive(false);
        transform.position = Vector3.MoveTowards(transform.position, LandingTransform.position, speed * Time.deltaTime);
        yield return new WaitForSeconds(4f);
        //yield return StartCoroutine(CameraReturnCoroutine());
        
        //transform.position = SpawnTransform.position;
        //yield return new WaitForSeconds(1);
        player.enabled = true;
        targetind.SetActive(true);
        gameObject.GetComponent<CameraTracking>().enabled = true;
        panned = true;

    }
     IEnumerator CameraReturnCoroutine()
    {
        transform.position = Vector3.MoveTowards(LandingTransform.position, transform.position, speed * Time.deltaTime);
        yield return new WaitForSeconds(4);

    }

}
