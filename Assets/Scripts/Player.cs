using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    //enum ModeSwitching {Start, Impulse, Acceleration, Force, VelocityChange};
    //ModeSwitching m_ModeSwitching;
    [SerializeField] GameObject PlayerLeftHalf;
    [SerializeField] GameObject PlayerRightHalf;
    [SerializeField] float thrust;
    [SerializeField] float impulseForce;

    [SerializeField] float torque;
    [SerializeField] float thrustDelay;

    Coroutine leftThrustCoroutine;
    Coroutine rightThrustCoroutine;

    GameObject SpawnPlatform;
    Transform startPosition;

    /*private void Awake()
    {
        int numberPlayers = FindObjectsOfType<Player>().Length;
        if (numberPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        SpawnPlayer();
    }

    private void Start()
    {
        SpawnPlayer();
    }*/

    void OnEnable()
    {
        //SceneManager.sceneLoaded += OnSceneLoaded;
        //Debug.LogError("Player --- On Enable --- Finished");

    }
    void OnDisable()
    {
        //SceneManager.sceneLoaded -= OnSceneLoaded;
        //Debug.LogError("Player --- On Disable --- Finished");

    }


    //I have to pass in / use scene and mode in UnityEngines existing delegate method. 
    /*void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Debug.LogError("Player --- OnSceneLoaded --- Finished");
        if (scene.name.Contains("Start Menu"))
        {
            gameObject.SetActive(false);
            return;
        } else
        {
            SpawnPlayer();

        }

    }*/

    private void Start()
    {
        SpawnPlayer();
    }
    // Update is called once per frame
    void Update()
    {
        Fire();

    }

    private void Fire()
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
                                          SpawnPlatform.transform.position.y + 10f,
                                          SpawnPlatform.transform.position.z);
        PlayerLeftHalf.transform.position = new Vector3(SpawnPlatform.transform.position.x,
                                          SpawnPlatform.transform.position.y + 10f,
                                          SpawnPlatform.transform.position.z);
        PlayerRightHalf.transform.position = new Vector3(SpawnPlatform.transform.position.x,
                                          SpawnPlatform.transform.position.y + 10f,
                                          SpawnPlatform.transform.position.z);

        transform.eulerAngles = new Vector3(0, 0, 0);
        PlayerRightHalf.transform.eulerAngles = transform.eulerAngles;
        PlayerLeftHalf.transform.eulerAngles = transform.eulerAngles;
        PlayerRightHalf.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        PlayerRightHalf.GetComponent<Rigidbody2D>().angularVelocity = 0;
        PlayerLeftHalf.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        PlayerLeftHalf.GetComponent<Rigidbody2D>().angularVelocity = 0;
        //Debug.Log("Player --- SpawnPlayer() --- Finished");
    }
}
