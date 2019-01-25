using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float rotationSpeed;
    
    private float xForce;
    private float zForce;
    private Vector3 force;
    private float pitch = 0.0F;
    private float yaw = 0.0F;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
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

        //pitch -= Input.GetAxis("Mouse Y");
        yaw += Input.GetAxis("Mouse X") * rotationSpeed;

        force = new Vector3(xForce, 0.0F, zForce);

        // rotate object to face mouse direction
        rb.transform.localEulerAngles = new Vector3(pitch, yaw, 0.0F);

        // move object in facing direction relative to local (AddRelative) not world (AddForce) coordinates
        rb.AddRelativeForce(force);
    }
}
