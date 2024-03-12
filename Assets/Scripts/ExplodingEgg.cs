using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingEgg : MonoBehaviour
{
    
    [SerializeField] float BulletSpeed = 2.0f;
    private int numBounces = 0;
    [SerializeField] float BlastRadius;
    [SerializeField] float ExplosionForce;
    private bool hasExploded = false;
    public bool seeRadius = false;


    // Start is called before the first frame update
    void Start()
    {
        
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        // get mouse position and translate it to 2D world position, borrowed from unity tutorial-1 (290)
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        Vector2 shootDirection = mousePos2D - new Vector2(transform.position.x, transform.position.y);
        rb.velocity = shootDirection * BulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // destroy egg 
        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "Room" )
        {
            numBounces++;
            if (numBounces > 1 && !hasExploded)
            {
                
                Debug.Log("BOOM!!");
                Explode();
            }
                     
        }
       
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && !hasExploded)
        {
            FindObjectOfType<AudioManager>().PlaySound("Peck");
            Debug.Log("BOOMM");
            Explode();
        }
    }

    // inspired from @https://www.youtube.com/watch?v=BYL6JtUdEY0
    void Explode()
    {
        hasExploded = true;
        FindObjectOfType<AudioManager>().PlaySound("C12explosion");
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, BlastRadius);
        Destroy(gameObject);
        foreach(Collider2D col in cols)
        {
            if (col.tag == "Breakable")
            {
                Debug.Log(col.name);
                col.GetComponent<Rigidbody2D>().AddForce(new Vector2(ExplosionForce, ExplosionForce), ForceMode2D.Impulse);
                Destroy(col.gameObject);
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (seeRadius)
        {
            Gizmos.DrawSphere(transform.position, BlastRadius);
        }
        
    }


}
