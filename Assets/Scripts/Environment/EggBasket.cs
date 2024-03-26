using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBasket : MonoBehaviour
{
    [SerializeField]
    GameObject wall;
    [SerializeField]
    Sprite greenBasket;
    [SerializeField]
    AudioSource eggIn;
    [SerializeField]
    AudioSource doorOpen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Egg"))
        {
            eggIn.Play();
            SpriteRenderer sp = gameObject.GetComponent<SpriteRenderer>();           
            sp.sprite = greenBasket;
            wall.SetActive(false);
            doorOpen.Play();
            collision.gameObject.SetActive(false);
           
        }
    }
}
