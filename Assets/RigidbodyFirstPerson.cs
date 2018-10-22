using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

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
	private RaycastHit hit;
	public bool cupHit = false;
	public bool coffeeHit = false;
	public AudioClip tryGrab;
	public AudioSource playerAudio;
	//this variable will remember input and pass it to physics 
	private Vector3 inputVector;
	public GameObject grabbedObject;
	private Transform tempTrans;
	public GameObject guideoObject;
	public bool winTouch = false;

	public AudioSource memes;

	public bool grabbed = true;
	// Update is called once per frame
	void Update () {
		Debug.Log(GameManager.Instance.PFindDisable);
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
			grabbed = true;		
			playerAudio.PlayOneShot(tryGrab);

			tempTrans = grabbedObject.transform.parent;

			grabbedObject.transform.parent = guideoObject.transform;

			grabbedObject.transform.position = guideoObject.transform.position;


		}
		//else
		//{
		//	grabbed = false;
		//	grabbedObject.transform.parent = null; 
		//}

		if (Input.GetKey(KeyCode.E) && coffeeHit == true)
		{
			GameManager.Instance.hasCoffe = true;
			Debug.Log("want some coffee!");
			memes.Play();

		}

		if (Input.GetKey(KeyCode.E) && winTouch == true)
		{
			if (GameManager.Instance.hasCoffe == true)
			{
				Debug.Log("You Win");
				SceneManager.LoadScene(3);
			}
			else {Debug.Log("Die in a fire");
			}
		}
		Raycasting();

		
	}
	// it runs every physics frame( a different framerate than input or rendering 
	void FixedUpdate()
	{
		
		GetComponent<Rigidbody>().velocity = inputVector * moveSpeed + Physics.gravity * .5f;
	}	
	
	void Raycasting () {
		//Define Ray
		Ray interactRay = new Ray(transform.position, transform.forward);
		//Define maxraycast distance
		float maxRaycastDistance = 1f;
		//Define Raycast hit variable
		RaycastHit myRayHit = new RaycastHit(); 
		//Visualize the raycast
		Debug.DrawRay(interactRay.origin, interactRay.direction * maxRaycastDistance,Color.green);
		//Shoot Raycast!!

		if (Physics.Raycast(interactRay, out myRayHit, maxRaycastDistance))
		{
			switch(myRayHit.collider.tag)

			{

				case "Cup":
				{
					Debug.Log("Cuphit!!");
					cupHit = true;
					//playerAudio.PlayOneShot(tryGrab);
					GameManager.Instance.CanGrab = true;
					break;
				}
				case "Keurig":
				{
					Debug.Log("Coffee Maker");
					coffeeHit = true;
					GameManager.Instance.CanGrab = true;
					break;
				}
				case "Winner":
				{
					winTouch = true;
					
					break;
				}
				default:
				{
					cupHit = false;
					coffeeHit = false;
					winTouch = false;
					break;
				}
					break;
			}
			
			
			
			
			
			
			
			
			
			
			/*
			if (myRayHit.collider.tag.Equals("Cup"))	
			{
				Debug.Log("Cuphit!!");
				cupHit = true;
				//playerAudio.PlayOneShot(tryGrab);
				GameManager.Instance.CanGrab = true;
			}
			
			if (myRayHit.collider.tag.Equals("Kuerig") && coffeeHit == false)
			{
				Debug.Log("Coffee Maker");
				coffeeHit = true;
				GameManager.Instance.CanGrab = true;
			}
			if (!myRayHit.collider.tag.Equals("Cup"))
			{
				cupHit = false;
				GameManager.Instance.CanGrab = false;
			}
			if (!myRayHit.collider.tag.Equals("Kuerig"))

			{
				coffeeHit = false;
				GameManager.Instance.CanGrab = false;
			}
			if (myRayHit.collider.tag.Equals("WinObject"))
			{
				winTouch = true;
			}
			*/
			
			
			
		}
		
		
		//grabCast = Physics.Linecast (pSightStart.position, pSightEnd.position, 1<< LayerMask.NameToLayer("Grabbable"));
		//interactCast = Physics.Linecast (pSightStart.position, pSightEnd.position, 1<< LayerMask.NameToLayer("Coffee"));
		//interact = Physics2D.Linecast (pSightStart.position, pSightEnd.position, 1<< LayerMask.NameToLayer("Item"));

	}
	
	

	private void OnMouseDown()
	{
		throw new System.NotImplementedException();
	}
}
