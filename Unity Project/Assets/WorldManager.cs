using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{

    public GameObject floor;
    public GameObject Wall;
    public GameObject[] sideBuildings;

    public Transform parentForFloors;
    public Transform parentForDeadEnd;

    public float floorSize = 30;
   void Start(){
       SpawnFirstIteration();
       
   }
    void SpawnFirstIteration()
    {
        Vector3 SpawnPos = new Vector3(0,1.05f,24);
        for (int i = 0; i < floorSize; i++)
        {
            Instantiate(floor,SpawnPos,Quaternion.identity,parentForFloors);
            SpawnPos += new Vector3(0,0,10);
        }

        Debug.Log("Z POs is:"+SpawnPos.z);

        // Spawn Dead End Wall :)

        Instantiate(Wall,new Vector3(0,5.4f,SpawnPos.z),Quaternion.Euler(-90,0,0),parentForDeadEnd);




    }
}
