using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatManager : MonoBehaviour
{
   
    public Rat[] rats;
    private IEnumerator coroutine;
    private void Start()
    {
      
        foreach (Rat r in rats)
        {
            r.rat.GetComponent<RatsRatsRats>().setStartPoint(r.startPoint);
            r.rat.GetComponent<RatsRatsRats>().setEndPoint(r.endPoint);
           
        }
        Debug.Log("Tryin to spawn rat");
        StartCoroutine(SpawnRat(2f));


    }

    IEnumerator SpawnRat(float waitTime)
    {
        Debug.Log(Time.time);
        int point = Random.Range(0, rats.Length);
        Instantiate(rats[point].rat, rats[point].startPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(waitTime);
        Debug.Log(Time.time);
        StartCoroutine(SpawnRat(waitTime));
    }
}
