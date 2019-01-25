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
        if (destructionWhitelist.Contains(collider.gameObject.tag)) return;
        Destroy(collider.gameObject);
    }
}
