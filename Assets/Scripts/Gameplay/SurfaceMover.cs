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
		MoveToSurface();
		MakeDirectionNormal(transform.TransformVector(Vector3.up));
	}
	
	// Update is called once per frame
	void Update () {
		
		float radius = worldObject.localScale.x / 2f;
		Vector3 velocity = transform.TransformDirection(localVelocity);
		Vector3 previousUp = transform.position - worldObject.position;

		Vector3 newPos = transform.position + velocity * 0.033f;
		Vector3 normal2 = newPos - worldObject.position;

		// Following the trajectory will probably lift us off the surface
		// of the sphere, so we need to adjust
		float distFromCenter = Mathf.Lerp(normal2.magnitude, radius + hoverDistance, 0.5f);
		newPos = distFromCenter * normal2.normalized;

		if (faceMovement && velocity.magnitude > 0) {
			transform.rotation = Quaternion.LookRotation(velocity, normal2);
		}

		transform.position = newPos;
		MakeDirectionNormal(previousUp);
	}

	void MakeDirectionNormal(Vector3 dir) {

		Vector3 normal2 = transform.position - worldObject.position;

		float rotationFromCurvature = Vector3.Angle(dir, normal2);
		Vector3 rotationAxis = Vector3.Cross(dir, normal2);

		transform.Rotate(rotationAxis, rotationFromCurvature, Space.World);
	}

	void MoveToSurface() {
		float radius = worldObject.localScale.x / 2f;
		Vector3 normal = transform.position - worldObject.position;
		normal.Normalize();
		Vector3 newPos = (radius + hoverDistance) * normal;
		transform.position = newPos;
	}
}
