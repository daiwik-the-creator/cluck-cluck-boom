
using TMPro;
using UnityEngine;


public class goldenEggCounter : MonoBehaviour
{
    public TextMeshProUGUI mytxt;
    public PlayerStats player;
    public ElevatorLoader myEle;
    void Update()
    {
        mytxt.text = "FUSES:" + player.getGoldenEggCount() + "/"  + myEle.getRequiredGoldenEggs();
    }
}
