
using TMPro;
using UnityEngine;


public class goldenEggCounter : MonoBehaviour
{
    public TextMeshProUGUI mytxt;
    public PlayerStats player;
    void Update()
    {
        mytxt.text = "G_Eggs:" + player.getGoldenEggCount() + "/3";
    }
}
