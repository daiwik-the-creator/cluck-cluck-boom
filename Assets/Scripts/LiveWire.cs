using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveWire : MonoBehaviour
{
    bool isLive = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        StartCoroutine(Live());
    }

    IEnumerator Live()
    {
        isLive = !isLive;

        if (isLive)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        } else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }

        yield return new WaitForSeconds(1.5f);
        StartCoroutine(Live());
    }

}
