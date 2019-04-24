using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighFiveCollision : MonoBehaviour {

	[SerializeField]
	HighFiveController highFiveController;
	// Use this for initialization
	void Start () {
		highFiveController = GameObject.Find("Player").GetComponent<HighFiveController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){

		Debug.Log("Hand Was Triggered with "+other.gameObject.name);

		if(other.CompareTag("NPCHand")){
			highFiveController.OnHandShake(this.transform.position);
		}

		else if(other.CompareTag("PoliceHand")){
			
			GameManager.instance.OnHandCuffed();
		}
	}
}
