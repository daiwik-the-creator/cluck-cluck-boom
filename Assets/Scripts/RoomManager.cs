using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    List<GameObject> Rooms = new List<GameObject>();
    private GameObject currRoom;
    
        
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Room"))
        { 

            if (currRoom == null)
            {
                
                currRoom = other.transform.GetChild(0).transform.gameObject;
                AddRoom(currRoom);
                currRoom.SetActive(true);

            }
            else
            {
                AddRoom(other.transform.GetChild(0).transform.gameObject);
                if (currRoom != other.transform.GetChild(0).transform.gameObject && IsGreater(other.transform.GetChild(0).transform.gameObject, currRoom))
                {
                    currRoom.SetActive(false);
                    currRoom = other.transform.GetChild(0).transform.gameObject;
                    currRoom.SetActive(true);

                }

            }
            
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Room")) 
        {
          
            if (Rooms.Contains(other.transform.GetChild(0).transform.gameObject))
            {
                other.transform.GetChild(0).transform.gameObject.SetActive(false);
                RemoveRoom(other.transform.GetChild(0).transform.gameObject);
                if (Rooms.Count >= 1)
                {
                    int temp = -1;
                    int prio = -1;
                    for (int i = 0; i < Rooms.Count; i++)
                    {
                        if (Rooms[i].GetComponent<CinemachineVirtualCamera>().Priority > prio)
                        {
                            prio = Rooms[i].GetComponent<CinemachineVirtualCamera>().Priority;
                            temp = i;
                        }
                    }

                    
                    Rooms[temp].SetActive(true);
                    currRoom = Rooms[temp];
                }         
            }
        }
    }


    private void AddRoom(GameObject room)
    {
        if (!Rooms.Contains(room))
        {
            Rooms.Add(room);
        }
    }

    private void RemoveRoom(GameObject room)
    {
        if (Rooms.Contains(room))
        {
            Rooms.Remove(room);
        }
    }

    
    public bool IsGreater(GameObject x, GameObject y)
    {
        if (x.GetComponent<CinemachineVirtualCamera>().Priority > y.GetComponent<CinemachineVirtualCamera>().Priority)
        {
            return true;
        }

        return false;
    }

}
