using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover : MonoBehaviour
{
    public GameObject gameoverMenu;

    public void EnableGameOverMenu()
    {
        gameoverMenu.SetActive(true);
    }
}
