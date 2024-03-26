using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthDisplay : MonoBehaviour
{
    private int health = 5;
    public Text healthText;

    void Update()
    {
      healthText.text = "Health: " + health;

    }
}
