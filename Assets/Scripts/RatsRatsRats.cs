using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatsRatsRats : MonoBehaviour
{
    private Transform startPoint;
    private Transform endPoint;
    public float ratSpeed = 0.5f;
    public Sprite RatWithEgg;
    public GameObject collectableEgg;
    public Transform spawnEgg;
    private Vector2 target;
   

    private void Start()
    {      
        Run();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Hit Player");
            gameObject.GetComponent<SpriteRenderer>().sprite = RatWithEgg;
            //collision.GetComponent<PlayerStats>().EggShot();
            //Instantiate(collectableEgg,spawnEgg);
            Destroy(gameObject, 3f);   // steal egg and dissapear after 3 seconds

        }
    }

    public void Run()
    {
        Debug.Log("run boi");
        target = new Vector2(endPoint.position.x, endPoint.position.y);
        Vector2 start = new Vector2(startPoint.position.x, startPoint.position.y);
        Vector2 dir = target - start;
        gameObject.GetComponent<Rigidbody2D>().velocity = dir * ratSpeed;
        
        
    }

    private void Update()
    {
        // remove mouse when it gets to end point. 
        if (Vector2.Distance(transform.position,target) < 1)
        {
            Destroy(gameObject);
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
