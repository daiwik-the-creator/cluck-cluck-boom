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
        player = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(!player.IsGrounded()) {
                // spawn the egg only when player is in air. 
                Instantiate(egg, shootingPoint.position, transform.rotation);
            }
                       
        }
   }    
}
