using UnityEngine.SceneManagement;
using UnityEngine;

public class ElevatorLoader : MonoBehaviour
{
    private int goldeneggCcount = 0;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "GoldenEgg")
        {
            if(goldeneggCcount == 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            
        }
    }
}
