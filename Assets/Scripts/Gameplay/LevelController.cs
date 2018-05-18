using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : Singleton<LevelController> {

	public GameObject[] powerUpPrefabs;
	public GameObject[] enemyPrefabs;
	public PlayerController playerPrefab; 
	public int numPowerUps;
	public int numEnemies;
	private WorldController world;
	// Use this for initialization
	void Start () {
		world = GameObject.FindWithTag("World").GetComponent<WorldController>();
		SpawnPlayerShip();
		SpawnPowerUps();
		SpawnEnemies();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnPlayerShip()
	{
		var pos = world.radius * Vector3.up;
		Instantiate(playerPrefab, pos, Quaternion.identity);
	}

	void SpawnPowerUps() {
		for (int i = 0; i < numPowerUps; i++) {
			int idx = Random.Range(0, powerUpPrefabs.Length);
			Vector3 pos = Random.onUnitSphere * world.radius;
			GameObject.Instantiate(powerUpPrefabs[idx], pos, Random.rotationUniform);
		}
	}

	void SpawnEnemies() {
		for (int i = 0; i < numEnemies; i++) {
			int idx = Random.Range(0, enemyPrefabs.Length);
			Vector3 pos = Random.onUnitSphere * world.radius;
			GameObject.Instantiate(enemyPrefabs[idx], pos, Random.rotationUniform);
		}
	}
}
