using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftUp : MonoBehaviour
{
	Vector3 objPosition;
	public GameObject item;
	public GameObject tempParent;
	public bool isHolding = false;
	
	
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
			
	}

	private void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.tag ==  "liftable")
		{
			GameManager.Instance.CanGrab = true;
			Debug.Log("CanGrab= true");
		}
	}
}
