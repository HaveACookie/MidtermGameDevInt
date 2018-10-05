using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyApproach : MonoBehaviour
{

	 public Guard1 myGuard;
	// Use this for initialization
	void Start ()
	{
		myGuard = GetComponent<Guard1>();
	}
	
	// Update is called once per frame
	void Update () {
		//if (GameManager.Instance.PFindDisable == false)
		//{
		//	myGuard.enabled = false;
		//	Debug.Log("Set To false");
		//}
		//else if (GameManager.Instance.PFindDisable == true)
		///{
			//myGuard.enabled = true;
		//}
	}
}
