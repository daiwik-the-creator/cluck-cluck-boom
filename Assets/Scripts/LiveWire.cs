using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveWire : MonoBehaviour
{
    Color c;
    public bool isLive = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        c = gameObject.GetComponent<SpriteRenderer>().color;
        StartCoroutine(Live());
    }

    IEnumerator Live()
    {
        isLive = !isLive;

        if (isLive)
        {
            /*gameObject.GetComponent<SpriteRenderer>().color = Color.blue;*/
            gameObject.GetComponent<SpriteRenderer>().color = c;

        } else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }

        yield return new WaitForSeconds(1.5f);
        StartCoroutine(Live());
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enteres");
    }

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Coll");
        if (isLive)
        {
            Debug.Log(other.gameObject.CompareTag("Player"));
            if (other.gameObject.CompareTag("Player"))
            {
                other.GetComponent<PlayerStats>().InflictDamage(1);
            }
        }
    }

}
