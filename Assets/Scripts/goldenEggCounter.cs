
using TMPro;
using UnityEngine;


public class goldenEggCounter : MonoBehaviour
{
    public TextMeshProUGUI mytxt;
    public PlayerStats player;
    public ElevatorLoader myEle;
    void Update()
    {
        mytxt.text = "" + player.getGoldenEggCount() + "/"  + myEle.getRequiredGoldenEggs();
    }
}
