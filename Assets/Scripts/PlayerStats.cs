using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{

    [SerializeField] int startHealth;
    [SerializeField] int startEggCount;
    public int health = 3;
    private int eggCount = 2;
    private List<GameObject> inventory;

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        eggCount = startEggCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InflictDamage(int damage)
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
        Debug.Log("Hit: " +  collision.gameObject.name);
        if(collision.gameObject.tag == "eggCollectable")
        {
            eggCount++;
            Destroy(collision.gameObject);
        }
    }

    public int getEggCount()
    {
        return eggCount;
    }

    public void EggShot()
    {
        eggCount--;
    }

    private void ResetScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
