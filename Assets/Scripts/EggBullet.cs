using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBullet : MonoBehaviour
{
    
    [SerializeField] float bulletSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // get mouse position and translate it to 2D world position, borrowed from unity tutorial-1 (290)
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        Vector2 shootDirection = mousePos2D - new Vector2(transform.position.x, transform.position.y);
        rb.velocity = shootDirection * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag != "Player")
        {
            Destroy(gameObject);
        }
       
    }

   
}
