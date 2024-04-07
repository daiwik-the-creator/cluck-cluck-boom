using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CrushingPlatform : MonoBehaviour
{
    public float upspeed;
    public float downspeed;
    private bool chop;
    private Vector3 up, down;
    [SerializeField] AudioSource crusher;
    [SerializeField] AudioSource playerCrushed;

    void Start()
    {
        up = transform.position;
        down = transform.GetChild(0).transform.position;
    }

    // code insp https://www.youtube.com/watch?v=1Jr4Y-U6_M4&t=179s
    void Update()
    {
        if (transform.position.y >= up.y)
        {
            chop = true;
        }

        if (transform.position.y <= down.y)
        {
            crusher.Play();
            chop = false;
        }
        if (chop)
        {
            transform.position = Vector2.MoveTowards(transform.position, down, downspeed * Time.deltaTime);
        }
        else
        {

            transform.position = Vector2.MoveTowards(transform.position, up, upspeed * Time.deltaTime);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (collision.collider.GetComponent<PlayerMovement>().IsGrounded() && Mathf.Abs(collision.collider.GetComponent<Rigidbody2D>().position.x - down.x) < 1.5)
            {
                StartCoroutine(CrushPlayer(collision.collider));
                
                //collision.collider.GetComponent<PlayerStats>().InflictDamage(5);
            }
        }
    }

    IEnumerator CrushPlayer(Collider2D player)
    {
        /*        player.enabled = false;*/
        playerCrushed.Play();
        yield return new WaitForSeconds(0f);
        player.GetComponent<PlayerStats>().InflictDamage(5);
        /*        player.enabled = true;*/ 
    }

   
}