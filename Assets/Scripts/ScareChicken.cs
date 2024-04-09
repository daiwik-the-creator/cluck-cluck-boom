using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ScareChicken : MonoBehaviour
{
    public GameObject scarechiken;
    public new Light2D light;
    public  Light2D globalLight;
    private bool isInside = false;
    private bool spawned = false;
    [SerializeField] private PlayerMovement player;


    private void Update()
    {
        if (isInside)
        {
            StartCoroutine(flicker(0.5f));
        }

            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GetComponent<AudioSource>().Play();
            light.enabled = true;
            globalLight.intensity = 0.3f;
            isInside = true;
            Debug.Log("player entered the chat.");
            StartCoroutine(InstantiateScareChiken());


        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            light.enabled=false;
            globalLight.intensity = 1;
            Debug.Log("player left the chat.");
            isInside = false;
            spawned = false;
        }
    }

    IEnumerator flicker(float t)
    {
        Debug.Log("trying flicker");
        light.intensity = 0;
        yield return new WaitForSeconds(t);
        light.intensity = 1;
      
    }

    IEnumerator InstantiateScareChiken()
    {
        
        yield return new WaitForSeconds(3f);
        Debug.Log("spawned scare boi");
        if(!spawned)
            Instantiate(scarechiken,transform.position, Quaternion.identity);
        spawned = true;
        if (!player.isStealthing && isInside)
        {
            player.GetComponent<PlayerStats>().InflictDamage(1);
        }
        isInside = false;

    }

}
