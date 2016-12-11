using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour 
{
	public Transform[] wayPointList;

	public int currentWayPoint = 0;
	Transform targetWayPoint;

	public float speed = 0.0125f;

	public bool midDesk = false;

	void Update() 
	{
		if (!midDesk) {
			if (currentWayPoint < this.wayPointList.Length) {
				if (targetWayPoint == null) {
					targetWayPoint = wayPointList [currentWayPoint];
				}
				// Move to target
				move ();
			} else {
				// Teleport back to beginning
				warp ();
			}
		}
	}

	private void move() 
	{
		transform.position = Vector3.MoveTowards (
			transform.position, 
			targetWayPoint.position,
			speed * Time.deltaTime
		);

		if (transform.position == targetWayPoint.position) {
			currentWayPoint++;
			if (currentWayPoint == 4) {
				midDesk = true;
			}

			if (currentWayPoint < this.wayPointList.Length) {
				targetWayPoint = wayPointList [currentWayPoint];
			}
		}

	}

	private void warp()
	{
		currentWayPoint = 0;
		targetWayPoint = wayPointList [currentWayPoint];
		transform.position = wayPointList[currentWayPoint].position;
	}
}
