using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LiveWire : MonoBehaviour
{
    Color c;
    public bool isLive = false;
    public int damage = 1;
    
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
            FindObjectOfType<AudioManager>().PlayLiveWire();
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
            if (other.gameObject.CompareTag("Player") && other.GetComponent<PlayerStats>().isElectrocuted == false)
            {
                // Fix for multiple electrocutions.
                
                other.GetComponent<PlayerStats>().isElectrocuted = true;
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
        Vector2 startPos = player.transform.position;
        while (isLive)
        {
            player.transform.position = startPos + Random.insideUnitCircle * .1f;
            yield return null;
        }
        player.GetComponent<PlayerStats>().InflictDamage(damage);
        FindObjectOfType<AudioManager>().PlaySound("hurt");
        player.GetComponent<PlayerStats>().isElectrocuted = false;

    }

}
