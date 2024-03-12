using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CrushingPlatform : MonoBehaviour
{
    public float upspeed;
    public float downspeed;
    public Transform up;
    public Transform down;
    bool chop;
    Vector3 org;

    // Start is called before the first frame update
    void Start()
    {
       org = up.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= org.y)
        {
            chop = true;
        }

        if (transform.position.y <= down.position.y)
        {
            chop = false;
        }
        if (chop)
        {
            transform.position = Vector2.MoveTowards(transform.position, down.position, downspeed * Time.deltaTime);
        } else
        {
            transform.position = Vector2.MoveTowards(transform.position, org, upspeed * Time.deltaTime);
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerStats>().InflictDamage(5);
        }
    }
}
