using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    private GameObject prevCam;
    private GameObject currCam;
    bool OverRide = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Room"))
        {
            if (currCam == null)
            {
                currCam = other.transform.GetChild(0).transform.gameObject;
                currCam.SetActive(true);
            } else
            {
                if (currCam != other.transform.GetChild(0).transform.gameObject && currCam.GetComponent<CinemachineVirtualCamera>().Priority < other.transform.GetChild(0).GetComponent<CinemachineVirtualCamera>().Priority)
                {
                    currCam.SetActive(false);
                    prevCam = currCam;
                    currCam = other.transform.GetChild(0).transform.gameObject;
                    currCam.SetActive(true);
                }
            }
            
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Room") && OverRide == false)
        {
            GameObject temp = currCam;

            
            currCam.SetActive(false);
            prevCam.SetActive(true); 
            
            currCam = prevCam;
            prevCam = temp;
        }
    }

    /*private void OnTriggerStay2D(Collider2D other)
    {
        int p1 = 0;
        int p2 = 0;

        if (other.CompareTag("Room"))
        {
            p2 = p1;
            p1 = other.transform.GetChild(0).GetComponent<CinemachineVirtualCamera>().Priority;
            if (p1 != p2)
            {
                OverRide = true;
            } else
            {
                OverRide = false;
            }
        }
            
    }*/

}
