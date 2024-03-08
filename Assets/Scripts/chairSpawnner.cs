using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chairSpawnnner : MonoBehaviour
{
    public Vector3 orgLocation;

    private void Start()
    {
        orgLocation = gameObject.transform.localPosition;
    }

    public void resetPos()
    {
        gameObject.transform.localPosition = orgLocation;
    }

    public void pecked(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1);
        if (hit.collider.CompareTag("Ground"))
        {
            Debug.Log("mmm");
        }
    }
}
