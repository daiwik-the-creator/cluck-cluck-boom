using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairCrusher : MonoBehaviour
{
    [SerializeField] AudioSource crush;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Peckable"))
        {
            transform.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(CrushChair(1, collision.collider));
            
        }       
    }

    IEnumerator CrushChair(int delay, Collider2D chair)
    {
        crush.Play();
        yield return new WaitForSeconds(delay);
        transform.GetComponent<SpriteRenderer>().enabled = true;
        chair.GetComponent<chairSpawnnner>().resetPos();
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        crush.Play();
    }

}
