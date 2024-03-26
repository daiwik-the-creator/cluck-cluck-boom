using UnityEngine.SceneManagement;
using UnityEngine;

public class ElevatorLoader : MonoBehaviour
{
    //private int goldeneggCcount = 0;
    [SerializeField] private int GoldenEggsRequired; 
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            //goldeneggCcount++;
            if(col.GetComponent<PlayerStats>().getGoldenEggCount() == GoldenEggsRequired)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            
        }
    }
}
