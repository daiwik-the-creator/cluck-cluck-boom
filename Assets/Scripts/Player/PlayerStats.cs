using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] int startHealth;
    [SerializeField] int startEggCount;
    [SerializeField] int c12count;
    public int health = 3;
    private int eggCount = 3;
    private int boomEggCount = 0;
    public float goldenEggs = 0;
    private bool collected = false; // using to fix the bug where 2 eggs are added. 
    //private List<GameObject> inventory;
    private AudioManager am;
    public bool isElectrocuted = false;
    public Respawn respawn;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        eggCount = startEggCount;
        am = gameObject.GetComponent<PlayerMovement>().am;
    }


    public void InflictDamage(int damage)  // damage the player. 
    {
        am.PlaySound("hurt");
        health -= damage;
        if (health <= 0)
        {
            health = 3;
            Debug.Log("lmaoded");
            respawn.GetComponent<Respawn>().Spawn();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        //Debug.Log("Hit: " +  collision.gameObject.name);
        if(collision.gameObject.tag == "GoldenEgg")  // inrease egg count when player collides with a collectable egg. 
        {
            am.PlaySound("EggPickUp");
            Destroy(collision.gameObject);
            Debug.Log("increasign count" + collision.gameObject.name);
            goldenEggs += 0.5f;
              
        }

        if (collision.gameObject.tag == "C12")  // inrease egg count when player collides with a collectable egg. 
        {
            am.PlaySound("c12PickUp");
            boomEggCount+=3;
            Destroy(collision.gameObject);
        }


    }


    public int getEggCount() // returns the egg count of the player. 
    {
        return eggCount;
    }

    public int getExploEggCount() // returns the exploding egg count of the player. 
    {
        return boomEggCount;
    }

    public void EggShot() // reduce egg count when egg is shot or a rat steals an egg.
    {
        eggCount--;
    }
    public void ExploEggShot() // reduce explo egg count
    {
        boomEggCount--;
    }

    private void ResetScene() // reset the current scene
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void eggInc() // used to add eggs (invoked in another script) 
    {
        eggCount++;
    }

    public float getGoldenEggCount()
    {
        return goldenEggs; 
    }

    private void resetCollected()
    {
        collected = false;
    }
    
}
