using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Respawn : MonoBehaviour
{
    [SerializeField] public GameObject Beakley;
    List<Vector3> RespawnPoints = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<transform.childCount; i++)
        {
            RespawnPoints.Add(transform.GetChild(i).position);
            transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
        }
        /*Debug.Log(RespawnPoints.Count);*/
    }

    public void Spawn()
    {
        GameObject currCam = Beakley.transform.GetComponent<RoomManager>().currentCamera();
        int spawnIndex = currCam.name.ToCharArray().Last() - '0';
        Beakley.transform.localPosition = RespawnPoints[spawnIndex -1];
    }


}
