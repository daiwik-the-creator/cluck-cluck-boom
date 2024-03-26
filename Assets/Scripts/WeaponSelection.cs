using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelection : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;

    private int currentWeaponIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        button1.onClick.AddListener(() => SelectWeapon(0));
        button2.onClick.AddListener(() => SelectWeapon(1));
        button3.onClick.AddListener(() => SelectWeapon(2));

        SelectWeapon(currentWeaponIndex);

    }
    void SelectWeapon(int index)
    {
        ColorBlock colors1 = button1.colors;
        colors1.normalColor = Color.white;
        button1.colors = colors1;

        ColorBlock colors2 = button2.colors;
        colors2.normalColor = Color.white;
        button2.colors = colors2;

        ColorBlock colors3 = button3.colors;
        colors3.normalColor = Color.white;
        button3.colors = colors3;

        if (index == 0)
            button1.GetComponent<Image>().color = Color.green;
        else if (index == 1)
            button2.GetComponent<Image>().color = Color.green;
        else if (index == 2)
            button3.GetComponent<Image>().color = Color.green;
        currentWeaponIndex = index;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
