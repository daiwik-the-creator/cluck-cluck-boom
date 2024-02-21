using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    public GameObject virtualCam;
    private GameObject previousVirtualCam;


    void Update()
    {
       /* Debug.Log();*/
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger) {
            virtualCam.SetActive(true);
            DeactivateOtherVirtualCameras(virtualCam);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            virtualCam.SetActive(false);
        }
    }

    private void DeactivateOtherVirtualCameras(GameObject currentVirtualCam)
    {
        // Find all virtual cameras in the scene
        CinemachineVirtualCameraBase[] virtualCameras = FindObjectsOfType<CinemachineVirtualCameraBase>();

        // Deactivate all virtual cameras except the current one
        foreach (CinemachineVirtualCameraBase cam in virtualCameras)
        {
            if (cam.gameObject != currentVirtualCam)
            {
                cam.gameObject.SetActive(false);

            }
        }
    }
}
