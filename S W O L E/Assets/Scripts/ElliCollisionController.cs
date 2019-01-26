using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElliCollisionController : MonoBehaviour
{
  private HashSet<string> destructionWhitelist = new HashSet<string>() { "MefakedHaorvim" };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("mamazav");
        var collidedGameObject = collider.gameObject;
        if (destructionWhitelist.Contains(collidedGameObject.tag)) return;

        // If there is no "destroyedObject" defined it means we're in the "destroyed" version of our object,
        // and not the original one. Hence, we don't re-spawn a destroyed object infinitely...
        else
        {
            collidedGameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    /*void OnTriggerEnter(Collider collider)
    {
        Debug.Log("mamazav");
        var collidedGameObject = collider.gameObject;
        if (destructionWhitelist.Contains(collidedGameObject.tag)) return;

        // Try obtaining the "destroyedObject" part of the object we're going to destroy.
        // This is necessary for visual effects - everytime we are about to destroy an object,
        // we want to instantiate a "destroyedObject" that takes care of the animations.
        var destroyedObject = collidedGameObject.GetComponent<DestructibleObject>();

        // Destroy(collider.gameObject);

        if (destroyedObject != null)
        {
            var actualDestroyedObject = destroyedObject.destroyedObject;
            Destroy(collider.gameObject);
            Instantiate(actualDestroyedObject, collidedGameObject.transform.position, collidedGameObject.transform.rotation);
        }
        // If there is no "destroyedObject" defined it means we're in the "destroyed" version of our object,
        // and not the original one. Hence, we don't re-spawn a destroyed object infinitely...
        else
        {
            collidedGameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }*/
}
