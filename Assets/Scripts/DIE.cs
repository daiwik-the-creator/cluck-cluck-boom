using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class DIE : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnColliderEnter2D(Collision other)
    {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerStats>().InflictDamage(100);
        }

    }

}
