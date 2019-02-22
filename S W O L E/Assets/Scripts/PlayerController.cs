﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float rotationSpeed;
    private float yaw = 0.0F;
    public bool enableRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float y = transform.localPosition.y;
        var ogRotation = rb.transform.localEulerAngles;


        // move relative to blue arrow
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition -= transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += transform.right * speed * Time.deltaTime;
        }

        if (enableRotation)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);

            //pitch -= Input.GetAxis("Mouse Y");
            yaw += Input.GetAxis("Mouse X") * rotationSpeed;

            // rotate object to face mouse direction
            rb.transform.localEulerAngles = new Vector3(0.0F, yaw, 0.0F);
        }

        if (transform.localPosition.z <= -10)
        {
            transform.localPosition = new Vector3(transform.position.x, transform.position.y, -10);
        }
        if (transform.localPosition.z >= 49)
        {
            transform.localPosition = new Vector3(transform.position.x, transform.position.y, 49);
        }
        if (transform.localPosition.x <= -23)
        {
            transform.localPosition = new Vector3(-23, transform.position.y, transform.position.z);
        }
        if (transform.localPosition.x >= 47)
        {
            transform.localPosition = new Vector3(47, transform.position.y, transform.position.z);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("sssup");
        Debug.Log(col.collider.gameObject.tag);
        // TODO - LOL REMOVE THIS FUCKING SHIT
        if (col.collider.gameObject.tag == "Zumbi")
        {
            col.collider.gameObject.GetComponent<Rigidbody>().useGravity = true;
            Destroy(col.collider.gameObject, 5.0f);
        }
    }
}
