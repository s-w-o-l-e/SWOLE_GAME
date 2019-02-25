using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class EndgameScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForKeyPress(KeyCode.Return, () => SceneManager.LoadScene(0)));
    }

    IEnumerator WaitForKeyPress(KeyCode keyCode, Action callback)
    {
        Debug.Log("OMG LOOL");
        yield return new WaitUntil(() => Input.GetKeyUp(keyCode));
        callback();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
