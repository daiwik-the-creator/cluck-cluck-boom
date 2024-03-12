using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ChairCrusher : MonoBehaviour
{
    [SerializeField]
    GameObject crusher;
    [SerializeField] bool isPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)   // Turn on 
    {
        if (collision.gameObject.tag == "Peckable")
        {
            Debug.Log("Chair detected");    
            gameObject.GetComponent<SpriteRenderer>().enabled = (false);
            //transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
            
            collision.collider.GetComponent<chairSpawnnner>().resetPos();
            
            transform.GetComponent<SpriteRenderer>().enabled = true;
            transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }

    }

}
