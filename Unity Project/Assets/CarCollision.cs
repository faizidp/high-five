using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour {



	void OnTriggerEnter(Collider collider)
	{
		Debug.Log("Collided with :"+collider.tag);
		if(collider.CompareTag("PlayerBody") || collider.CompareTag("PlayerHand"))
		{
			GameManager.instance.OnCollidedWithPoliceCar();
		}
	}
}
