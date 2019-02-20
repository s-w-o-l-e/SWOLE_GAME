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
        // If it isn't destroyed by then, destroy the shell after it's lifetime.
        Destroy(gameObject, m_MaxLifeTime);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Rigidbody target = col.GetComponent<Rigidbody>();
            // Reduce health from player
            
            // Play the explosion sound effect.
            // Should be on the player
            m_ExplosionAudio.Play();

            // Destroy the shell.
            Destroy(gameObject);
        }
    }
}
