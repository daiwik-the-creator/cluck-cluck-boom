using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SetOpacity(0.1f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<PlayerStats>().InflictDamage(100);
    }

    public void SetOpacity(float opacity)
    {
        opacity = Mathf.Clamp01(opacity);
        Color spriteColor = GetComponent<SpriteRenderer>().color;
        spriteColor.a = opacity;
        GetComponent<SpriteRenderer>().color = spriteColor;
    }
}
