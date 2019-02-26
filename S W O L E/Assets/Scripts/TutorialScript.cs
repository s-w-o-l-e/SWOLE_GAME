using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    private bool bSwallowedItem;
    private bool bSwallowedZombie;
    public GameObject TutorialText;

    // Start is called before the first frame update
    void Start()
    {
        bSwallowedItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bSwallowedItem)
        {
            TutorialText.GetComponent<UnityEngine.UI.Text>().text = "Find a smaller zombie to swallow!";
            TutorialText.GetComponent<UnityEngine.UI.Text>().color = Color.blue;
        }
        if (bSwallowedZombie)
        {
            //TutorialText.GetComponent<UnityEngine.UI.Text>().enabled = false;
            TutorialText.GetComponent<UnityEngine.UI.Text>().color = Color.green;
            TutorialText.GetComponent<UnityEngine.UI.Text>().text = "Great! Swallow all the zombies to advance to the next level!";
        }
    }

    void OnEnable()
    {
        EventManagerController.StartListening("SwallowMapItem", () =>
        {
            bSwallowedItem = true;
        });
        EventManagerController.StartListening("SwallowZumbi", () =>
        {
            bSwallowedZombie = true;
        });
    }
}
