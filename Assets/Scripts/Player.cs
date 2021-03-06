using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [SerializeField] GameObject PlayerLeftHalf;
    [SerializeField] GameObject PlayerRightHalf;
    [SerializeField] float thrust;
    [SerializeField] float impulseForce;
    [SerializeField] float torque;
    [SerializeField] float thrustDelay;
    Coroutine leftThrustCoroutine;
    Coroutine rightThrustCoroutine;

    float spawnOffset = 10f;
    GameObject SpawnPlatform;
    Transform startPosition;
    public static int level = -1;
    public bool retry = false;

    void OnEnable()
    {
        //SceneManager.sceneLoaded += OnSceneLoaded;

    }
    void OnDisable()
    {
        //SceneManager.sceneLoaded -= OnSceneLoaded;
        //Debug.LogError("Player --- On Disable --- Finished");
        level = SceneManager.GetActiveScene().buildIndex;

    }


    private void Awake()
    {
        SpawnPlayer();
    }
    // Update is called once per frame
    void Update()
    {
        Fire();

    }

    public void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            PlayerLeftHalf.GetComponent<Rigidbody2D>().AddRelativeForce(Vector3.up * impulseForce, ForceMode2D.Impulse);

            leftThrustCoroutine = StartCoroutine(FireLeft());
            PlayerLeftHalf.GetComponentInChildren<ParticleSystem>().Play();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(leftThrustCoroutine);
            PlayerLeftHalf.GetComponentInChildren<ParticleSystem>().Stop();

        }


        if (Input.GetButtonDown("Fire2"))
        {
            PlayerRightHalf.GetComponent<Rigidbody2D>().AddRelativeForce(Vector3.up * impulseForce, ForceMode2D.Impulse);

            rightThrustCoroutine = StartCoroutine(FireRight());
            PlayerRightHalf.GetComponentInChildren<ParticleSystem>().Play();

            //deathSFX.Play();
        }
        if (Input.GetButtonUp("Fire2"))
        {
            StopCoroutine(rightThrustCoroutine);
            PlayerRightHalf.GetComponentInChildren<ParticleSystem>().Stop();

        }

    }

    IEnumerator FireLeft()
    {
        while (true)
        {
            PlayerLeftHalf.GetComponent<Rigidbody2D>().AddRelativeForce(Vector3.up * thrust);
            PlayerLeftHalf.GetComponent<Rigidbody2D>().AddTorque(-torque);
            yield return new WaitForSeconds(thrustDelay);
        }
    }
    IEnumerator FireRight()
    {
        while (true)
        {
            PlayerRightHalf.GetComponent<Rigidbody2D>().AddRelativeForce(Vector3.up * thrust);
            PlayerRightHalf.GetComponent<Rigidbody2D>().AddTorque(torque);
            yield return new WaitForSeconds(thrustDelay);
        }
    }
    public void SpawnPlayer()
    {
        SpawnPlatform = GameObject.FindGameObjectWithTag("SpawnPlatform");

        transform.position = new Vector3(SpawnPlatform.transform.position.x,
                                          SpawnPlatform.transform.position.y + spawnOffset,
                                          SpawnPlatform.transform.position.z);
        PlayerLeftHalf.transform.position = new Vector3(SpawnPlatform.transform.position.x,
                                          SpawnPlatform.transform.position.y + spawnOffset,
                                          SpawnPlatform.transform.position.z);
        PlayerRightHalf.transform.position = new Vector3(SpawnPlatform.transform.position.x,
                                          SpawnPlatform.transform.position.y + spawnOffset,
                                          SpawnPlatform.transform.position.z);

        transform.eulerAngles = new Vector3(0, 0, 0);
        PlayerRightHalf.transform.eulerAngles = transform.eulerAngles;
        PlayerLeftHalf.transform.eulerAngles = transform.eulerAngles;
        PlayerRightHalf.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        PlayerRightHalf.GetComponent<Rigidbody2D>().angularVelocity = 0;
        PlayerLeftHalf.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        PlayerLeftHalf.GetComponent<Rigidbody2D>().angularVelocity = 0;
    }
}
