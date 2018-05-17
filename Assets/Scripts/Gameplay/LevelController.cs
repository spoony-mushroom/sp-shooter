using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	public GameObject[] powerUpPrefabs;
	public GameObject[] enemyPrefabs;
	public int numPowerUps;
	public int numEnemies;
	private WorldController world;
	// Use this for initialization
	void Start () {
		world = GameObject.FindWithTag("World").GetComponent<WorldController>();
		SpawnPowerUps();
		SpawnEnemies();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnPowerUps() {
		for (int i = 0; i < numPowerUps; i++) {
			int idx = Random.Range(0, powerUpPrefabs.Length);
			Vector3 pos = Random.onUnitSphere * world.radius;
			GameObject.Instantiate(powerUpPrefabs[idx], pos, Random.rotationUniform);
		}
	}

	void SpawnEnemies() {

	}
}
