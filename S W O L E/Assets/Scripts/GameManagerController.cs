using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour
{
    public Camera fpsCam;
    public Camera topCamIsAlsoMainCam;
    public GameObject playerhomo;
    private Vector3 smdlastRotation;

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
        EventManagerController.StartListening("HealDamage", () => {playerhomo.GetComponent<Healthbar>().HealDamage(1.0f);});
        EventManagerController.StartListening("TakeDamage", () =>
        {
            playerhomo.GetComponent<Healthbar>().TakeDamage(5.0f);
            playerhomo.GetComponent<AudioSource>().Play();
        });
    }
}
