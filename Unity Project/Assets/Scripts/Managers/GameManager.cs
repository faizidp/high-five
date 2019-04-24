using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


	public static GameManager instance = null;

	public PlayerController playerController;
	
	void Awake()
	{
		instance = this;
	}
	void Start()
	{
		playerController = GameObject.Find("Player").GetComponent<PlayerController>();
	}

	public void OnHandCuffed(){
		Debug.Log("You are hand cuffed! (Busted i.e. :(");
		playerController.shallRunForward  = false;

		UIManager.instance.OnGameOver();
	}
	public void OnCollidedWithPoliceCar(){
		Debug.Log("You collided with Police Car... Now You are really in trouble!");
		playerController.shallRunForward  = false;
		UIManager.instance.OnGameOver();

	}
}
