using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private int score = 0;

    void OnEnable()
    {
        EventManagerController.StartListening("SwallowMapItem", () =>
        {
            score += 100;
            gameObject.GetComponent<Text>().text = "Score: " + score;
        });
    }
}
