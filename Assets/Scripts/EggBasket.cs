using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBasket : MonoBehaviour
{
    [SerializeField]
    GameObject wall;
    [SerializeField]
    Sprite greenBasket;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Egg"))
        {
            SpriteRenderer sp = gameObject.GetComponent<SpriteRenderer>();           
            sp.sprite = greenBasket;
            wall.SetActive(false);
           
        }
    }
}
