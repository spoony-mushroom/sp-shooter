using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceMover : MonoBehaviour {

	public Vector3 localVelocity;
	// private Transform worldObject;
	public float hoverDistance = 0.5f;
	public bool faceMovement = true;

	public Transform worldObject { get; private set; }

	// Use this for initialization
	void Start () {		
		worldObject = GameObject.FindWithTag("World").transform;
		float radius = worldObject.localScale.x / 2f;
		transform.position = worldObject.position + Vector3.up * (radius + hoverDistance);
	}
	
	// Update is called once per frame
	void Update () {
		
		float radius = worldObject.localScale.x / 2f;
		Vector3 velocity = transform.TransformDirection(localVelocity);
		Vector3 normal1 = transform.position - worldObject.position;

		Vector3 newPos = transform.position + velocity * 0.033f;
		Vector3 normal2 = newPos - worldObject.position;
		float distFromCenter = Mathf.Lerp(normal2.magnitude, radius + hoverDistance, 0.5f);
		newPos = distFromCenter * normal2.normalized;

		float rotationFromCurvature = Vector3.Angle(normal1, normal2);
		Vector3 rotationAxis = Vector3.Cross(normal1, normal2);

		if (faceMovement && velocity.magnitude > 0) {
			transform.rotation = Quaternion.LookRotation(velocity, normal2);
		}

		transform.position = newPos;
		transform.Rotate(rotationAxis, rotationFromCurvature, Space.World);
	}
}
