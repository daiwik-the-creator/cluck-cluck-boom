using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chairSpawnnner : MonoBehaviour
{
    public Vector3 orgPosition;
    public Quaternion orgRotation;

    private void Start()
    {
        orgPosition = gameObject.transform.localPosition;
        orgRotation = gameObject.transform.localRotation;

    }

    public void resetPos()
    {
        gameObject.transform.localPosition = orgPosition;
        gameObject.transform.localRotation = orgRotation;
    }

}
