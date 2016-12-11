using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour 
{
	public Transform[] wayPointList;

	public int currentWayPoint = 0;
	Transform targetWayPoint;

	public float speed = 0.0125f;

	public Quaternion ogRot;
	public Quaternion finRot;

	public bool midDesk = false;
	public bool awaitingDecisionMrPresident = false;
	public bool decisionMade = false;

	void Start()
	{
		ogRot  = transform.rotation;
		finRot = Quaternion.Euler (-45, transform.rotation.x, transform.rotation.z);
	}

	void Update() 
	{
		if (currentWayPoint == 4 && !decisionMade) {
			midDesk = true;
		} else if (currentWayPoint == 4 && decisionMade) {
			midDesk = false;
		}

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
		} else if (midDesk && !awaitingDecisionMrPresident) {
			while (transform.rotation != finRot) {
				transform.rotation = Quaternion.Lerp (
					transform.rotation,
					finRot,
					speed * Time.deltaTime
				);
			}
			awaitingDecisionMrPresident = true;
		} else if (midDesk && awaitingDecisionMrPresident) {
			if (Input.GetMouseButtonDown (0)) {
				while (transform.rotation != ogRot) {
					transform.rotation = Quaternion.Lerp (
						transform.rotation,
						ogRot,
						speed * Time.deltaTime
					);
				}

				decisionMade = true;
				midDesk = false;
				awaitingDecisionMrPresident = false;
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

			if (currentWayPoint < this.wayPointList.Length) {
				targetWayPoint = wayPointList [currentWayPoint];
			}
		}

	}

	private void warp()
	{
		decisionMade = false;
		currentWayPoint = 0;
		targetWayPoint = wayPointList [currentWayPoint];
		transform.position = wayPointList[currentWayPoint].position;
	}
}
