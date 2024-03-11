using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LiveWire : MonoBehaviour
{
    Color c;
    public bool isLive = false;
    public float damage = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Start");
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
            gameObject.GetComponent<BoxCollider2D>().enabled = true;

        } else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        yield return new WaitForSeconds(1.5f);
        StartCoroutine(Live());
    }

   void OnTriggerEnter2D(Collider2D other)
    {
        if (isLive)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                StartCoroutine(ElectrocutePlayer(other));
            }

            else if(other.tag == "Peckable")
            {
                other.gameObject.GetComponent<chairSpawnnner>().resetPos();
            }
            
        }

    }

    IEnumerator ElectrocutePlayer(Collider2D player)
    {
        Debug.Log("IM hERE");

        Vector2 startPos = player.transform.position;
        player.GetComponent<PlayerStats>().InflictDamage(damage);
        while (isLive)
        {
            player.transform.position = startPos + Random.insideUnitCircle * .1f;
            yield return null;
        }
        
    }

}
