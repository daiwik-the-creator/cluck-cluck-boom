using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class ElevatorLoader : MonoBehaviour
{
    //private int goldeneggCcount = 0;
    [SerializeField] private int GoldenEggsRequired;
    [SerializeField] private AudioSource levelComplete;
    [SerializeField] public bool isEnd = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            //goldeneggCcount++;
            if(col.GetComponent<PlayerStats>().getGoldenEggCount() >= GoldenEggsRequired)
            {
                StartCoroutine(wait(3f));
            }
            
        }
    }

    IEnumerator wait(float t)
    {
        levelComplete.Play();
        yield return new WaitForSeconds(t);
        if (isEnd)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - SceneManager.GetActiveScene().buildIndex);
        } else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        



    }

    public int getRequiredGoldenEggs()
    {
        return GoldenEggsRequired;
    }
}
