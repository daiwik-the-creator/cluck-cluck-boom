using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class eggShooter : MonoBehaviour
{
    PlayerMovement player;
    public GameObject egg;
    public GameObject explodingEgg;
    public Transform shootingPoint;
    private Animator _animator;

    private String curEgg = "Egg";
    //private PlayerStats playerStats;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerMovement>();
        StartCoroutine(IncreaseEgg());
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) )
        {
            // shoot egg
            if(curEgg == "Egg" && !player.IsGrounded() && gameObject.GetComponent<PlayerStats>().getEggCount() > 0) {
                // spawn the egg only when player is in air and has an egg in this inventory. 
                FindObjectOfType<AudioManager>().PlaySound("eggThrow");
                Instantiate(egg, shootingPoint.position, transform.rotation);
                gameObject.GetComponent<PlayerStats>().EggShot();
                _animator.SetBool(name: "Shooting", value: true);
            }

            // shoot c12
            else if (curEgg == "Bomb" && !player.IsGrounded() && gameObject.GetComponent<PlayerStats>().getExploEggCount() > 0)
            {
                // spawn the egg only when player is in air and has an egg in this inventory. 
                FindObjectOfType<AudioManager>().PlaySound("c12Throw");
                Instantiate(explodingEgg, shootingPoint.position, transform.rotation);
                gameObject.GetComponent<PlayerStats>().ExploEggShot();
                _animator.SetBool(name: "Shooting", value: true);
            }

        }

        // toggle between c12 and egg
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            curEgg = "Egg";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            curEgg = "Bomb";
        }
        
    }

    // making the no. of eggs unlimited and giving it a cooldown. 
    IEnumerator IncreaseEgg()
    {
        yield return new WaitForSeconds(2f);
        if (gameObject.GetComponent<PlayerStats>().getEggCount() <= 0)
        {
           gameObject.GetComponent<PlayerStats>().eggInc();
        }
        StartCoroutine(IncreaseEgg());
    }
}
