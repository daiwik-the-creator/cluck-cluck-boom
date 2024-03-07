using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chairSpawnnner : MonoBehaviour
{
    public Transform Desk;

    public void resetPos()
    {
        transform.position = Desk.position; 
    }
}
