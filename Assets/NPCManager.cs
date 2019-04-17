using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour {

	public GameObject NormalNPC;		// NORMAL PEDESTRIANS with whom High FIve is objective
	public Color[] RandomColorsToPickFrom;


	public GameObject PoliceNPC;
	public GameObject PoliceCar;

	public float normalNPCSpawnPosX = 2;		
	
	public float zPosSpawnOffset = 10;

		// For NPCs
	public int numberOfPedestrians = 30;

	public Transform spawnParentNormalNPC;
	public Transform spawnParentPoliceNPC;
	public Transform spawnParentPoliceCar;

	enum SpawnSide {
		Left,
		Right
	}
	
	enum NPCType {

		Normal,
		Police,
		PoliceCar
	}
	void Start () {
		SpawnPedestrians();
	}
	
	void SpawnPedestrians(){
		float currentZPos = -10;
		for(int i = 0; i< numberOfPedestrians; i++){

			Color currentColor = Color.black;
			SpawnSide currentSpawnSide; 	// to which Side this pedestrian shall spawn? 
			Vector3 spawnPosition;			// Transform Position to Spawn in World Space
			NPCType currentNPCType;			


		
			
			// Which NPC Type to Spawn?

			currentNPCType = ChooseNPCType();

			// Color of NPC

			if(currentNPCType == NPCType.Normal)		// We don't want to change the color of Police
			{
				if(RandomColorsToPickFrom.Length > 0)
					currentColor = RandomColorsToPickFrom[Random.Range(0,RandomColorsToPickFrom.Length)];
			}
			
			// Randomly Choose the side to Spawn to
			int p = Random.Range(0,2);
			if(p == 0)
				currentSpawnSide = SpawnSide.Left;
			else
				currentSpawnSide = SpawnSide.Right;


			// Adjust Vector3 Position Accordingly
			if(currentSpawnSide == SpawnSide.Left)
				spawnPosition = new Vector3(-normalNPCSpawnPosX,1.56f,currentZPos);
			else 
				spawnPosition = new Vector3(normalNPCSpawnPosX,1.56f,currentZPos);		

			GameObject go = null;
			if(currentNPCType == NPCType.Normal)
			{
				go = Instantiate(NormalNPC,spawnPosition,Quaternion.identity,spawnParentNormalNPC);
			}
			else
			{
				go = Instantiate(PoliceNPC,spawnPosition,Quaternion.identity,spawnParentPoliceNPC);
			}

			if(currentNPCType == NPCType.Normal)
			{
				go.GetComponent<Renderer>().material.SetColor("_Color",currentColor);
			}

			// Spawn Police Car

			int carProb = Random.Range(0,100);
			if(carProb > 80)
			{
				// Spawn the Car... 
				// We need to make sure the Car Spawn Positioning is adjustable properly with User Experience
				// But for now, I'm just spawning somewhere in the middle between the position of next Player
				Vector3 carSpawnPosition;
				float xPos = Random.Range(-normalNPCSpawnPosX, normalNPCSpawnPosX);
				float zPos = Random.Range(currentZPos + 3,currentZPos +5);
				carSpawnPosition = new Vector3(xPos,1.56f,zPos);
				Instantiate(PoliceCar,carSpawnPosition,Quaternion.identity,spawnParentPoliceCar);
			}
			
			currentZPos += Random.Range(zPosSpawnOffset-3,zPosSpawnOffset+3);
		}
	}

	private NPCType ChooseNPCType()
	{
		/*  A Method to randomly choose between Police and Normal... 
		 Obviously we would want Normal NPCs to Spawn More.. 
		 This is just a dummy approach towards getting the desired result, we can improve the algorith 
		 with Weighted based Probability to have more control
		 */

		int i = Random.Range(0,11);

		if(i <= 7)
		{
			return NPCType.Normal;
		}
		else
		{
			return NPCType.Police;
		}
	}
}
