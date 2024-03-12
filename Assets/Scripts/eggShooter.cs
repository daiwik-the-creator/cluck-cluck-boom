using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class eggShooter : MonoBehaviour
{
    PlayerMovement player;
    public GameObject egg;
    public GameObject explodingEgg;
    public Transform shootingPoint;

    private String curEgg = "Egg";
    //private PlayerStats playerStats;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) )
        {

            if(curEgg == "Egg" && !player.IsGrounded() && gameObject.GetComponent<PlayerStats>().getEggCount() > 0) {
                // spawn the egg only when player is in air and has an egg in this inventory. 
                FindObjectOfType<AudioManager>().PlaySound("eggThrow");
                Instantiate(egg, shootingPoint.position, transform.rotation);
                gameObject.GetComponent<PlayerStats>().EggShot();
            }

            else if (curEgg == "Bomb" && !player.IsGrounded() && gameObject.GetComponent<PlayerStats>().getEggCount() > 0)
            {
                // spawn the egg only when player is in air and has an egg in this inventory. 
                FindObjectOfType<AudioManager>().PlaySound("c12Throw");
                Instantiate(explodingEgg, shootingPoint.position, transform.rotation);
                gameObject.GetComponent<PlayerStats>().EggShot();
            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            curEgg = "Egg";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            curEgg = "Bomb";
        }
   }    
}
