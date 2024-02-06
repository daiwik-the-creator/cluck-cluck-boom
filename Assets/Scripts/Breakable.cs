using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{

    bool isShaking = false;
    float shakeAmount = .1f;
    float shakeTime = .25f;
    Vector2 startPos;

    int hit = 0;
    [SerializeField] private int hitThreshold;

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
            transform.position = startPos + UnityEngine.Random.insideUnitCircle * shakeAmount;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PeckHitbox")
        {
            //damage
            isShaking = true;
            hit += 1;
            
            Invoke("StopShaking", shakeTime);

        }
    }

    void StopShaking()
    {
        isShaking = false;
        transform.position = startPos;
        if (hit >= hitThreshold)
        {
            Object.Destroy(this.gameObject);
        }
    }

}
