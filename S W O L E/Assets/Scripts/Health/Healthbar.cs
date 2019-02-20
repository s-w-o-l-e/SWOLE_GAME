using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Image currentHealthbar;
    public Text ratioText;

    private float hitpoint = 150;
    private float maxHitpoint = 150;

    private void UpdateHealthbar()
    {
        float ratio = hitpoint / maxHitpoint;
        currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 100).ToString() + '%';
    }

    public void TakeDamage(float damage)
    {
        hitpoint -= damage;

        if (hitpoint <= 0) {
            hitpoint = 0;
            Debug.Log("rip elli cu in petah tikwa lol");
        }

        UpdateHealthbar();
    }

    public void HealDamage(float heal)
    {
        hitpoint += heal;
        hitpoint = hitpoint > maxHitpoint ? maxHitpoint: hitpoint;
        UpdateHealthbar();
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealthbar();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
