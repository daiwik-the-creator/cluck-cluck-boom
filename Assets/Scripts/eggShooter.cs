using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class eggShooter : MonoBehaviour
{
    PlayerMovement player;
    public GameObject egg;
    public Transform shootingPoint;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            // spawn the egg
            Instantiate(egg, shootingPoint.position, transform.rotation);
           
        }

    }

    

}
