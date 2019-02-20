using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ElliCollisionController : MonoBehaviour
{
  // As explainted further in the code - no longer relevant.
  // private HashSet<string> destructionWhitelist = new HashSet<string>() { "MefakedHaorvim" };

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision) {
        Debug.Log($"Elli collides with {collision.collider.gameObject.name}");
    }

    void OnTriggerEnter(Collider collider)
    {
        // TODO - LOL REMOVE THIS FUCKING SHIT
        if (collider.gameObject.tag == "Zumbi")
        {
            // gameObject.transform.parent.SendMessage("TakeDamage", 5.0f);
            EventManagerController.TriggerEvent("TakeDamage");

        }
        // TODO - REMOVE THIS LOOL NEPHEW

        var collidedGameObject = collider.gameObject;
        Debug.Log($"Elli triggers with {collidedGameObject.name}");;

        // This piece of code is irrelevant as we now detect collision with a layer-based approach.
        // We don't have to programatically check for the Tag.
        /*if (destructionWhitelist.Contains(collidedGameObject.tag)) {
            Debug.Log("Triggered type of MefakedHaorvim. ignoring!");
            return;
        }*/

        var fixedElliScale = new Vector3(gameObject.transform.parent.transform.localScale.x * gameObject.transform.localScale.x,
            gameObject.transform.parent.transform.localScale.y * gameObject.transform.localScale.y,
            gameObject.transform.parent.transform.localScale.z * gameObject.transform.localScale.z);
        var collidedGameObjScale = collidedGameObject.transform.localScale;

        // Tried getting the mesh filter, from which i can get the mesh, from which i wanted to get
        // the canvas (is it the correct hierarchy?) for the scaleFactor. That way we won't need the 0.01 HACK.
        // var collidedGameObjMesh = collidedGameObject.GetComponent<MeshFilter>().mesh;
        // var calcedCollidedObjScale = collidedGameObjScale * collidedGameObject.GetComponent<Canvas>().scaleFactor;

        // WE ACTUALLY DON'T NEED SCALE FACTOR AT THE MOMENT, SO IT APPEARS!

        // HACK: We hardcodedingly use '0.01' as our scaleFactor. But it's not desirable or anything near that..
        // var calcedCollidedObjScale = collidedGameObjScale * 1 / 0.01f; // lol
        var calcedCollidedObjScale = collidedGameObjScale * 1;

        if (calcedCollidedObjScale.magnitude > fixedElliScale.magnitude) {
                Debug.Log($"Elli is smaller than {collidedGameObject.name}.");
                Debug.Log($"Elli size = {fixedElliScale.ToString()}. {collidedGameObject.name} size = {calcedCollidedObjScale.ToString()}");
                return;
        }

        var gameObjectToDestroy = collidedGameObject.tag == "Enemy" ? collidedGameObject.transform.parent.gameObject : collidedGameObject;

        collidedGameObject.GetComponent<Rigidbody>().useGravity = true;
        Debug.Log($"Destroying {gameObjectToDestroy.name}...");
        Destroy(gameObjectToDestroy, 2.0f);
        gameObject.transform.parent.transform.localScale += new Vector3(calcedCollidedObjScale.x, 0, calcedCollidedObjScale.z) * 0.5f;
        EventManagerController.TriggerEvent("HealDamage");
        // gameObject.transform.parent.SendMessage("HealDamage", 1.0f);
    }

    void OnTriggerExit(Collider collider) {

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
