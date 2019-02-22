using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    public float menuFadeTime = .5f;
    public Color sceneChangeFadeColor = Color.black;

    public void LoadByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
}
