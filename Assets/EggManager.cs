using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggManager : MonoBehaviour
{
    public int eggCount;
    public Text eggText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        eggText.text = "EGG: " + eggCount.ToString();
    }
}
