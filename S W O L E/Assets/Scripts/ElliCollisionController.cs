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
        Debug.Log(collidedGameObject.tag);
        if (destructionWhitelist.Contains(collidedGameObject.tag)) return;

        var elliScale = gameObject.transform.localScale;
        var collidedGameObjScale = collidedGameObject.transform.localScale;

        // Tried getting the mesh filter, from which i can get the mesh, from which i wanted to get
        // the canvas (is it the correct hierarchy?) for the scaleFactor. That way we won't need the 0.01 HACK.
        // var collidedGameObjMesh = collidedGameObject.GetComponent<MeshFilter>().mesh;
        // var calcedCollidedObjScale = collidedGameObjScale * collidedGameObject.GetComponent<Canvas>().scaleFactor;

        // WE ACTUALLY DON'T NEED SCALE FACTOR AT THE MOMENT, SO IT APPEARS!

        // HACK: We hardcodedingly use '0.01' as our scaleFactor. But it's not desirable or anything near that..
        // var calcedCollidedObjScale = collidedGameObjScale * 1 / 0.01f; // lol
        var calcedCollidedObjScale = collidedGameObjScale * 1;

        Debug.Log("BOX SCALE: X: " + calcedCollidedObjScale.x + " and Z: " + calcedCollidedObjScale.z);
        Debug.Log("Elli SCALE: X: " + elliScale.x + " and Z: " + elliScale.z);

        if (calcedCollidedObjScale.x > elliScale.x ||
            calcedCollidedObjScale.z > elliScale.z) return;

        // If there is no "destroyedObject" defined it means we're in the "destroyed" version of our object,
        // and not the original one. Hence, we don't re-spawn a destroyed object infinitely...
        collidedGameObject.GetComponent<Rigidbody>().useGravity = true;
        Destroy(collidedGameObject, 5.0f);
        Debug.Log("dead");
        gameObject.transform.localScale += new Vector3(calcedCollidedObjScale.x, 0, calcedCollidedObjScale.z) * 0.1f;
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
