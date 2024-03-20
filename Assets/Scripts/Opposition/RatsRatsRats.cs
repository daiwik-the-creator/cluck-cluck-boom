using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatsRatsRats : MonoBehaviour
{
    public Transform startPoint ;
    public Transform endPoint;
    public float ratSpeed = 0.5f;
    public Sprite RatWithEgg;
    //public GameObject collectableEgg;
   // public Transform spawnEgg;

   

    private void Start()
    {      
        Run();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Debug.Log("Hit Player");
            gameObject.GetComponent<SpriteRenderer>().sprite = RatWithEgg;
            //collision.GetComponent<PlayerStats>().EggShot();
            //Instantiate(collectableEgg,spawnEgg);
            Destroy(gameObject, 3f);   // steal egg and dissapear after 3 seconds

        }
    }

    public void Run()
    {
        
            Vector2 dir = new Vector2(endPoint.position.x, endPoint.position.y )- new Vector2(startPoint.position.x, startPoint.position.y);
            gameObject.GetComponent<Rigidbody2D>().velocity = dir * ratSpeed;
          
            //Debug.Log("RUNNN");
                   
        
    }

    private void Update()
    {
        // remove mouse when it gets to end point. 
        if(endPoint != null)
        {
            if (Vector2.Distance(transform.position, endPoint.position) < 1)
            {
                Destroy(gameObject);
            }
        }
       
       
    }

    public void setStartPoint(Transform sp)
    {
        startPoint = sp;
    }
    public void setEndPoint(Transform ep) { 
        endPoint = ep;
    }
}
