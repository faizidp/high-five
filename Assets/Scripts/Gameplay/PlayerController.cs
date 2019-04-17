using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum HandDirection {
		Left,
		Right,
		Normal
	}
public class PlayerController : MonoBehaviour {

	

	[SerializeField]
	SimpleTouchController screenTouch;

	HighFiveController highFiveController;

	[SerializeField]
	public float RunSpeed = 10;
	[SerializeField]
	float MoveSpeed = 5;		// Left, Right




	HandDirection currentHandDirection = HandDirection.Normal;
		
	
	public bool shallRunForward = true;
	public float limitHorizontalExtremes;

	CharacterController characterController;
	Vector3 moveTarget;
	float inputXForce;
	
	void Start () {
		characterController = GetComponent<CharacterController>();
		moveTarget = new Vector3(0,0,RunSpeed);
		highFiveController = GetComponent<HighFiveController>();
		currentHandDirection = HandDirection.Normal;
		OnHandDirectionChanged();
		
	
	}
	
	void FixedUpdate(){		
		if(shallRunForward)
		RunForward();
	}

	void RunForward()
	{
		characterController.Move(moveTarget*Time.deltaTime);
	}

	void OnHandDirectionChanged()
	{		
		highFiveController.ChangeHandDirection(currentHandDirection);
	}
	public	void MovePlayer(float xPos_)
	{
		if(xPos_ < 0 && currentHandDirection != HandDirection.Left){
			currentHandDirection = HandDirection.Left;
			OnHandDirectionChanged();
		}

		else if(xPos_ > 0 && currentHandDirection != HandDirection.Right){
			currentHandDirection = HandDirection.Right;
			OnHandDirectionChanged();
		}

		else if(xPos_ == 0 && currentHandDirection != HandDirection.Normal) {
			currentHandDirection = HandDirection.Normal;
			OnHandDirectionChanged();
		}

		var xPos = transform.position.x + (xPos_ *Time.deltaTime * MoveSpeed);
		 moveTarget = new Vector3(MoveSpeed*xPos_,0,RunSpeed);		
	}

}
