using System;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerController : MonoBehaviour
{
    public Camera fpsCam;
    public Camera topCamIsAlsoMainCam;
    public GameObject playerhomo;
    private Vector3 smdlastRotation;
    private bool hasGameEnded = false;

    public GameObject levelFailedUI;
    public GameObject levelFinishedUI;

    // Start is called before the first frame update
    void Start()
    {
        topCamIsAlsoMainCam.enabled = true;
        fpsCam.enabled = false;
        playerhomo.GetComponent<PlayerController>().enableRotation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            topCamIsAlsoMainCam.enabled = !topCamIsAlsoMainCam.enabled;
            fpsCam.enabled = !fpsCam.enabled;
            playerhomo.GetComponent<PlayerController>().enableRotation = fpsCam.enabled;

            if (topCamIsAlsoMainCam.enabled)
            {
                smdlastRotation = playerhomo.GetComponent<Rigidbody>().transform.localEulerAngles;
                playerhomo.GetComponent<Rigidbody>().transform.localEulerAngles = new Vector3(0.0F, 0.0F, 0.0F);
            }
            else
            {
                playerhomo.GetComponent<Rigidbody>().transform.localEulerAngles = smdlastRotation;
            }
        }
    }

    void OnEnable()
    {
        EventManagerController.StartListening("SwallowMapItem", () =>
        {
            playerhomo.GetComponent<Healthbar>().HealDamage(1.0f);

            var enemies = GameObject.FindGameObjectsWithTag("Zumbi");
            if (enemies.Length > 0)
            {
                return;
            }

            if (hasGameEnded)
            {
                return;
            }

            this.levelFinishedUI.SetActive(true);

            hasGameEnded = true;

            Debug.Log("gg faggots :)");

            StartCoroutine(WaitForKeyPress(KeyCode.Return, () =>  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1)));
        }
        );
        EventManagerController.StartListening("TakeDamage", () =>
        {
            playerhomo.GetComponent<Healthbar>().TakeDamage(5.0f);
            playerhomo.GetComponent<AudioSource>().Play();
        });
        EventManagerController.StartListening("GameOver", () =>
        {
            if (hasGameEnded)
            {
                return;
            }

            this.levelFailedUI.SetActive(true);

            hasGameEnded = true;

            Debug.Log("Game over losers :)");

            StartCoroutine(WaitForKeyPress(KeyCode.F, () => Restart()));
        });
    }

    IEnumerator WaitForKeyPress(KeyCode keyCode, Action callback)
    {
        Debug.Log("OMG LOOL");
        yield return new WaitUntil(() => Input.GetKeyUp(keyCode));
        callback();
    }

    void Restart()
    {
        Debug.Log("omg stfu");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
