using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthpointBarScript : MonoBehaviour
{
    private Color dangerColor = new Color(1.0f, 0.64f, 0.0f);
    private Color bleedingColor = Color.red;
    private Color healthyColorValue;

    // Start is called before the first frame update
    void Start()
    {
        healthyColorValue = GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.localScale.x > 0.75)
        {
            return;
        }

        if (gameObject.transform.localScale.x > 0.25)
        {
            GetComponent<Image>().color = dangerColor;
        }
        else
        {
            GetComponent<Image>().color = bleedingColor;
        }
    }
}
