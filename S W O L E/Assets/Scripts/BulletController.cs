using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public AudioSource m_ExplosionAudio;                // Reference to the audio that will play on explosion.
    public float m_MaxLifeTime = 5f;                    // The time in seconds before the shell is removed.

    // Start is called before the first frame update
    void Start()
    {
        // If it isn't destroyed by then, destroy the bullet after it's lifetime.
        // Need to find a way to shoot Prefab and not gameobject from the scene because it gets destroyed and nobody can shoot
        //Destroy(gameObject, m_MaxLifeTime);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.gameObject.tag == "Player")
        {
            // Reduce health from player

            // Play the hit sound effect on the player because were destroying this object

            // Destroy the shell.
            Destroy(gameObject);
            EventManagerController.TriggerEvent("TakeDamage");
        }
    }
}
