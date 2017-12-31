using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {

	public float radius;

	void Awake() {
		Update();
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {		
		transform.localScale = Vector3.one * radius;
	}
}
