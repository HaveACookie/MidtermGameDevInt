using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Guard1: MonoBehaviour {

	public float speed = 5;
	public float waitTime = .3f;
	public bool shouldMove = true;


	public Transform pathHolder;

	void Start()
	{

		


		Vector3[] waypoints = new Vector3[pathHolder.childCount];
		for (int i = 0; i < waypoints.Length; i++) {
			waypoints [i] = pathHolder.GetChild (i).position;   
		}

		StartCoroutine (FollowPath (waypoints));
			
	}

	 void Update()
	{
		shouldMove = GameManager.Instance.PFindDisable;
		Debug.Log(GameManager.Instance.PFindDisable);
	
	}


	IEnumerator FollowPath(Vector3[] waypoints) {
		transform.position = waypoints [0];
		int targetWaypointIndex = 1;
		Vector3 targetWaypoint = waypoints [targetWaypointIndex];

		while (true)
		{
			if (shouldMove == true) 
			{
					transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);
				if (transform.position == targetWaypoint)
				{
					targetWaypointIndex = (targetWaypointIndex + 1) % waypoints.Length;
					targetWaypoint = waypoints[targetWaypointIndex];
					yield return new WaitForSeconds(waitTime);
				}

				yield return null;
			}
			else if (shouldMove == false)
			{
				Debug.Log("Hi");
				yield return null;
			}
	}
	}

	void OnDrawGizmos(){
		Vector3 startPosition = pathHolder.GetChild (0).position;
		Vector3 previousPosition = startPosition; 

		foreach (Transform waypoint in pathHolder) {
			Gizmos.DrawSphere (waypoint.position, .3f);
			Gizmos.DrawLine (previousPosition, waypoint.position);
			previousPosition = waypoint.position; 

		}
		Gizmos.DrawLine (previousPosition, startPosition);
	}


		

}