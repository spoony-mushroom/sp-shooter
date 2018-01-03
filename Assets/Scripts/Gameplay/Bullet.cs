using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float lifeSpan = 1f;
	float aliveTime = 0;
	// Use this for initialization
	void Start () {
		
	}

	void OnEnable() {
		aliveTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		aliveTime += Time.deltaTime;
		if (aliveTime >= lifeSpan) {
			Pool.instance.Return<Bullet>(this);
		}
	}
}
