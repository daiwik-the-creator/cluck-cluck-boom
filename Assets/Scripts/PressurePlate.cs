using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    [SerializeField]
    GameObject greenButton;
    [SerializeField]
    GameObject platform;
    [SerializeField]
    SpriteRenderer disabledPlatform;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Peckable")
        {
            
            SpriteRenderer sp = gameObject.GetComponent<SpriteRenderer>();
            sp.enabled = false;

            greenButton.GetComponent<SpriteRenderer>().enabled = true;
            platform.GetComponent<BoxCollider2D>().enabled = true;
            platform.GetComponent<SpriteRenderer>().enabled = true;
            disabledPlatform.enabled = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Peckable")
        {

            SpriteRenderer sp = gameObject.GetComponent<SpriteRenderer>();
            sp.enabled = true;

            greenButton.GetComponent<SpriteRenderer>().enabled = false;
            platform.GetComponent<BoxCollider2D>().enabled = false;
            platform.GetComponent<SpriteRenderer>().enabled = false;
            disabledPlatform.enabled = true;
        }

    }
}
