using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweet : MonoBehaviour 
{
	public Transform[] wayPointList;
	public int currentWayPoint = 0;
	Transform targetWayPoint;
	public float speed = 0.5f;

	// This is for controlling tweets.
	/*
	 * Desired Functionality:
	 * Click when on desk to raise in front of view
	 * Click again to make tweet and return to place on desk
	 * 
	 * Plan:
	 * Will currently rise up to view on own, but will fluctuate between phoneWayPoints 3 and 4
	 * Change conditional in if statement to bool to control direction phone should move in. 
	 * Set bool by clicking on phone itself. 
	 * Will probably need a collider on gameObject to detect click
	 * /

	void Update()
	{
		if (currentWayPoint < this.wayPointList.Length) {
			if (targetWayPoint == null) {
				targetWayPoint = wayPointList [currentWayPoint];
			}

			move ();
		} else {
			moveBack ();
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

			if (currentWayPoint < this.wayPointList.Length) {
				targetWayPoint = wayPointList [currentWayPoint];
			}
		}
	}

	private void moveBack() 
	{
		transform.position = Vector3.MoveTowards (
			transform.position, 
			targetWayPoint.position,
			speed * Time.deltaTime
		);

		if (transform.position == targetWayPoint.position) {
			currentWayPoint--;

			if (currentWayPoint >= 0) {
				targetWayPoint = wayPointList [currentWayPoint];
			}
		}
	}
}
