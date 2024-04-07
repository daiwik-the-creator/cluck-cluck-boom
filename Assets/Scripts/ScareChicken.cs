using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ScareChicken : MonoBehaviour
{
    public GameObject scarechiken;
    public new Light2D light;
    public new Light2D globalLight;
    private bool isInside = false;


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
            globalLight.intensity = 0.3f;
            isInside = true;
            Debug.Log("player entered the chat.");
            StartCoroutine(flicker(0.5f));
            Instantiate(scarechiken);


        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            globalLight.intensity = 1;
            Debug.Log("player left the chat.");
            isInside = false;
        }
    }

    IEnumerator flicker(float t)
    {
        Debug.Log("trying flicker");
        light.intensity = 0;
        yield return new WaitForSeconds(t);
        light.intensity = 1;
        //if( isInside ) 
        //StartCoroutine(flicker(t));
    }
}
