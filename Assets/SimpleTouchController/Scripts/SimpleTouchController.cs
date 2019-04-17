using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class SimpleTouchController : MonoBehaviour {

	// PUBLIC
	public delegate void TouchDelegate(Vector2 value);
	public event TouchDelegate TouchEvent;

	public delegate void TouchStateDelegate(bool touchPresent);
	public event TouchStateDelegate TouchStateEvent;

	// PRIVATE
	[SerializeField]
	private RectTransform joystickArea;
	private bool touchPresent = false;
	private Vector2 movementVector;

	public PlayerController playerController;

	float moveForce;
	public Vector2 GetTouchPosition
	{
		get { return movementVector;}
	}


	public void BeginDrag()
	{
		touchPresent = true;
		if(TouchStateEvent != null)
			TouchStateEvent(touchPresent);
	}

	public void EndDrag()
	{
		touchPresent = false;
		movementVector = joystickArea.anchoredPosition = Vector2.zero;

		moveForce = 0;
		UpdatePlayerPosition(moveForce);

		if(TouchStateEvent != null)
			TouchStateEvent(touchPresent);

	}

	public void OnValueChanged(Vector2 value)
	{
						//Debug.Log("OnValueChanged...");

		if(touchPresent)
		{
			// convert the value between 1 0 to -1 +1
			movementVector.x = ((1 - value.x) - 0.5f) * 2f;
			movementVector.y = ((1 - value.y) - 0.5f) * 2f;

//				Debug.Log("OnValueChanged...");
				UpdatePlayerPosition(movementVector.x);

			if(TouchEvent != null)
			{
				TouchEvent(movementVector);
				
			}
		}

	}

	void UpdatePlayerPosition(float currentX){
		playerController.MovePlayer(currentX);
	}

}
