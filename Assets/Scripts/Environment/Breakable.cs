using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{

    bool isShaking = false;
    float shakeAmount = .1f;
    float shakeTime = .25f;
    Vector2 startPos;

    public int hit = 0;
    [SerializeField] private int hitThreshold;
    [SerializeField] private bool isGlass;
    

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShaking)
        {
            // Object shake in a small position https://forum.unity.com/threads/random-insideunitcirclea-around-a-certain-position.160257/
            transform.position = startPos + Random.insideUnitCircle * shakeAmount;
        }
    }

    // For static objects
    public void Hit()
    {
        //damage
        hit += 1;
        isShaking = true;
        Invoke("StopShaking", shakeTime);
            
    }

    // For dynamic objects
    public void Hit(Vector2 forceDirection, float force)
    {
        hit += 1;
        if (hit >= hitThreshold)
        {
            hit = 0;
            Vector2 forceToCancel = -forceDirection * force;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(forceToCancel, ForceMode2D.Impulse);

            gameObject.GetComponent<chairSpawnnner>().resetPos();
        }
    }

    void StopShaking()
    {
        isShaking = false;
        transform.position = startPos;
        if (hit >= hitThreshold)
        {
            if (isGlass)
            {
                FindObjectOfType<AudioManager>().PlaySound("glassBreak");
            }
            Destroy(gameObject,0.4f);
        }
    }

}
