using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offest;

    // Start is called before the first frame update
    void Start()
    {
        offest = transform.position - player.transform.position;
    }

    // Guarentee to run after all items have been processed in update
    void LateUpdate()
    {
        transform.position = player.transform.position + offest;
    }
}
