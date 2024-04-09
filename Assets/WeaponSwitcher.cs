using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitcher : MonoBehaviour

{
    public Image weaponImage; // assign in inspector
    public Sprite weapon1Sprite; // assign in inspector
    public Sprite weapon2Sprite; // assign in inspector
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponImage.sprite = weapon1Sprite;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponImage.sprite = weapon2Sprite;
        }
    }
}
