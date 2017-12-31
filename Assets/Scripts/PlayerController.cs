using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SurfaceMover))]
public class PlayerController : MonoBehaviour {
	private Transform mainCamera;
	public float controlSensitivity = 0.8f;
	public float maxSpeed = 10f;
	private SurfaceMover surfaceMover;

	// Use this for initialization
	void Start () {
		
		mainCamera = GameObject.FindWithTag("MainCamera").transform;
		surfaceMover = GetComponent<SurfaceMover>();
	}
	
	// Update is called once per frame
	void Update () {

		float moveX = Input.GetAxis("Horizontal");
		float moveY = Input.GetAxis("Vertical");

		Vector3 velocityControl = moveX * mainCamera.right + moveY * mainCamera.up;
		velocityControl = transform.InverseTransformDirection(velocityControl);
		surfaceMover.localVelocity = Vector3.Lerp(
			surfaceMover.localVelocity, 
			velocityControl * maxSpeed, 
			controlSensitivity);

		transform.rotation = GetInputAngle();
	}

	private Quaternion GetInputAngle() {
		Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10));
		Vector3 pointDir = touchPos - transform.position;
		pointDir = Vector3.ProjectOnPlane(pointDir, transform.up);
		return Quaternion.LookRotation(pointDir, transform.up);
	}

}
