﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHandCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider collider){
		//Debug.Log(collider.gameObject.tag);
	}
	void OnTriggerExit(Collider collider){

		//Debug.Log("Collission Exited with");
	}
}
