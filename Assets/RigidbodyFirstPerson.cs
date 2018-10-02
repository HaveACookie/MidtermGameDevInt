using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// usage: put this on Capsule with a Rigidbody
//this script does mouse look and WASD Movement for a player

public class RigidbodyFirstPerson : MonoBehaviour
{

	public float moveSpeed = 25f;
	public Transform objectInteract;
	public float grabbing;
	public bool canGrab; 
	public Transform pSightStart, pSightEnd;
	public bool interactCoffeeMaker;

	//this variable will remember input and pass it to physics 
	private Vector3 inputVector;
	// Update is called once per frame
	void Update () {
		// MOUSE LOOK!!!
		// getting mouse input
		// these are mouse "deltas" (delta = difference)
		// these will be 0 when nothing is moving, this isn't mouse position
		float mouseX = Input.GetAxis("Mouse X");// horizontal mouse movement
		float mouseY = Input.GetAxis("Mouse Y");//	vertical mouse movement
		
		// rotations : Pitch Yaw Roll
		// pitch = up/down rotation, X axis
		// yaw = left / right rotation, Y axis
		// roll = rolling motion, Z axis
		
		//rotate camera based on mouse input 
		//first, rotate body based on horizontal mouse movement 
		transform.Rotate( 0f, mouseX, 0f );
		Camera.main.transform.Rotate(-mouseY, 0f, 0f);
		
		
		
		//WASD MOVEMENT
		float horizontal = Input.GetAxis("Horizontal"); // A/D, Left/Right
		float vertical = Input.GetAxis("Vertical"); // W/S, Up/Down, Forward
		
		// apply keyboad input to position
		// teleportation movement 
		//transform.position += transform.forward * vertical;
		//transform.position += transform.right * horizontal; 
		// No collision detection


		inputVector = transform.forward * vertical;
		inputVector += transform.right * horizontal;

		if (Input.GetKey(KeyCode.E) && GameManager.Instance.CanGrab == true)
		{
			
		}
		
		Raycasting();

		
	}
	// it runs every physics frame( a different framerate than input or rendering 
	void FixedUpdate()
	{
		
		GetComponent<Rigidbody>().velocity = inputVector * moveSpeed + Physics.gravity * .5f;
	}
	
	void Raycasting () {
		Debug.DrawLine (pSightStart.position, pSightEnd.position, Color.green);
		//interact = Physics2D.Linecast (pSightStart.position, pSightEnd.position, 1<< LayerMask.NameToLayer("Item"));

	}

	private void OnMouseDown()
	{
		throw new System.NotImplementedException();
	}
}
