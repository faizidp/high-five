using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {


	public Transform playerTransform;



public float smoothSpeed = 0.125f;
	public Vector3 offset;
	
	// Use this for initialization
	void Start () {
		
	}
	void FixedUpdate(){
		follow();
	}
	// Update is called once per frame
	void Update () {
		//follow();
	}
	void follow(){
		Vector3 desiredPosition = playerTransform.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;

		transform.LookAt(playerTransform);
	}
}
