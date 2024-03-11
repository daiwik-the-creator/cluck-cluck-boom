using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] float startHealth;
    [SerializeField] int startEggCount;
    public float health = 50f;
    private int eggCount = 2;
    private List<GameObject> inventory;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        eggCount = startEggCount;
    }

    public void InflictDamage(float damage)  // damage the player. 
    {
        health -= damage;
        if (health <= 0)
        {
            Debug.Log("ded");
            ResetScene();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Hit: " +  collision.gameObject.name);
        if(collision.gameObject.tag == "eggCollectable")  // inrease egg count when player collides with a collectable egg. 
        {
            eggCount++;
            Destroy(collision.gameObject);
        }
    }

    public int getEggCount() // returns the egg count of the player. 
    {
        return eggCount;
    }

    public void EggShot() // reduce egg count when egg is shot or a rat steals an egg.
    {
        eggCount--;
    }

    private void ResetScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
