using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class HighFiveController : MonoBehaviour {

	[SerializeField]
	Transform leftHand;
	[SerializeField]
	Transform rightHand;

	[SerializeField]
	GameObject floatingScoreText;
	[SerializeField]
	GameObject worldSpaceCanvas;
	public float handLiftUpSpeed = 1;
	public float handLiftDownSpeed = 2;

	public float handUpRotation = 10;
	public float handDownRotation = 60;


	void Start(){
//		Debug.Log(rightHand.rotation.z);
	//	Debug.Log(leftHand.rotation.z);

		leftHand = GameObject.Find("Player").transform.Find("LeftHand");
		rightHand = GameObject.Find("Player").transform.Find("RightHand");
		floatingScoreText = Resources.Load("Prefabs/FloatingScore") as GameObject;

		worldSpaceCanvas = GameObject.Find("WorldCanvas");


		GetComponent<CharacterController>().detectCollisions = false;
		
	}
	public void ChangeHandDirection(HandDirection whichDirection){
		if(whichDirection == HandDirection.Left){
			lifeUpLeftHand();
			liftDownRightHand();

			Debug.Log("Lifting Up Left Hand...");
		}

		if(whichDirection == HandDirection.Right){
			lifeUpRightHand();
			lifeDownLeftHand();
			Debug.Log("Lifting Up Right Hand...");

		}

		if(whichDirection == HandDirection.Normal){
			/* 
			liftDownRightHand();
			lifeDownLeftHand();
			*/
//			Debug.Log("Lifting Down Both Hands...");

		}
	}

	public void OnHandShake(Vector3 handShakePosition){
		Debug.Log("Hand Shake Was Made!");
		AddScoreEfect(handShakePosition);

	}
	void AddScoreEfect(Vector3 spawnPos){
	var go=	Instantiate(floatingScoreText,spawnPos,Quaternion.identity,worldSpaceCanvas.transform);
	go.SetActive(true);
	TextMeshProUGUI textMesh = go.GetComponent<TextMeshProUGUI>();

	textMesh.rectTransform.DOScale(1,2);
	Vector3 addPos = new Vector3(0,3,0);
	textMesh.rectTransform.DOAnchorPos3D(textMesh.rectTransform.anchoredPosition3D + addPos,2);
	
	}
	
	void lifeUpRightHand(){
		rightHand.GetComponent<Animation>().Play("liftUpRightHand");

	}
	void lifeUpLeftHand(){
				leftHand.GetComponent<Animation>().Play("liftUpLeftHand");

	}
	void liftDownRightHand(){
		rightHand.GetComponent<Animation>().Play("liftDownRightHand");
	}
	void lifeDownLeftHand(){
				leftHand.GetComponent<Animation>().Play("liftDownLeftHand");

	}
}
