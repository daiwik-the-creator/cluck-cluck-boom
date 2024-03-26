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
            if (collision.collider.GetComponent<PlayerMovement>().IsGrounded())
            {
                StartCoroutine(CrushPlayer(collision.collider));
                
                //collision.collider.GetComponent<PlayerStats>().InflictDamage(5);
            }
        }
    }

    IEnumerator CrushPlayer(Collider2D playerCollider)
    {
/*        playerCollider.GetComponent<> = false;*/
        yield return new WaitForSeconds(0.5f);
        playerCollider.GetComponent<PlayerStats>().InflictDamage(5);
/*        playerCollider.enabled = true;*/
    }
}