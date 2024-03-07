using System.Collections;
using UnityEngine;

public class Peck : MonoBehaviour
{
    private bool isPecking = false;

    [SerializeField] private Rigidbody2D myRb;
    [SerializeField] private float peckForce;
    [SerializeField] private LayerMask peckable;

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
        Vector2 peckDirection = myRb.transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, peckDirection, 99, peckable);
        
        if (hit && (hit.collider.GetComponent<Rigidbody2D>().position.x - myRb.position.x) <= 1.75f) {
            if (hit.collider.CompareTag("Peckable"))
            {
                hit.rigidbody.AddForce(peckDirection * peckForce, ForceMode2D.Impulse);
            } else if (hit.collider.CompareTag("Breakable"))
            {
                hit.collider.GetComponent<Breakable>().Hit();
            }
        }
        
        yield return new WaitForSeconds(.2f);
        ResetPeck();
    }

private void ResetPeck()
    {
        isPecking = false;
    }

}
