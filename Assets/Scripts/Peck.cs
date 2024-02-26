using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;
using System.IO;

public class Peck : MonoBehaviour
{
    private bool isPecking = false;

    [SerializeField] private Rigidbody2D myRb;
    [SerializeField] private float peckForce;
    [SerializeField] private GameObject peckHitBox;
    // Start is called before the first frame update
    void Start()
    {
        peckHitBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift) && !isPecking)
        {
            isPecking = true;
            StartCoroutine(DoPeck());

        }
    }

    IEnumerator DoPeck()
    {
        peckHitBox.SetActive(true);
        yield return new WaitForSeconds(.2f);
        peckHitBox.SetActive(false);
        ResetPeck();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.tag == "Peckable")
        {

            Rigidbody2D otherRb = collision.GetComponent<Rigidbody2D>();
            if (otherRb != null)
            {

                Vector2 peckDirection = myRb.transform.localScale.x > 0 ? Vector2.right : Vector2.left;
                otherRb.AddForce(peckDirection * peckForce, ForceMode2D.Impulse);
            }
        }

    }

private void ResetPeck()
    {
        isPecking = false;
    }

}
