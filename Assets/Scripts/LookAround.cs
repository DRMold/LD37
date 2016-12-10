using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour 
{
	// -1 = false; +1 = true
	public int invertY = -1;
	public float mouseSensitivity = 50.0f;

	public float rotationX = 0.0f;
	public float rotationY = 0.0f;

	public float minX, maxX;
	public float minY, maxY;

	void Update ()
	{
		// Want to map rotations to opposite axes 
		rotationX += invertY * (Input.GetAxis ("Mouse Y") * mouseSensitivity * Time.deltaTime);
		rotationY += Input.GetAxis ("Mouse X") * mouseSensitivity * Time.deltaTime;
		rotationX = Mathf.Clamp (rotationX, minX, maxX);
		//rotationY = Mathf.Clamp (rotationY, minY, maxY);

		Quaternion localRotation = Quaternion.Euler (rotationX, rotationY, 0.0f);

		transform.rotation = localRotation;

		Debug.Log ("rotX: " + rotationX + " | rotY: " + rotationY 
			+" | MouseX: "+Input.GetAxis("Mouse X")+" | MouseY: "+Input.GetAxis("Mouse Y")
			+" | tf: " + transform.localRotation);
	}
}
