using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.WSA;

public class creditsswitcher : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject credits;

    public void ActivateCredits()
    {
        credits.SetActive(true);
    }

    public void DeactivateCredits()
    {
        credits.SetActive(false);
    }

  

}
