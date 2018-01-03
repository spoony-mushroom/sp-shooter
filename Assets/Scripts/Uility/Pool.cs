using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : Singleton<Pool> {
	
	public GameObject prefab;

	private Stack<GameObject> pool = new Stack<GameObject>();
	
	public T Take<T>() {
		GameObject obj = null;
		if (pool.Count > 0) {
			obj = pool.Pop();
		} else {
			obj = GameObject.Instantiate(prefab);
		}
		obj.SetActive(true);
		return obj.GetComponent<T>();
	}

	public void Return<T>(T obj) where T : MonoBehaviour {
		GameObject go = obj.gameObject;
		pool.Push(go);
		go.SetActive(false);
	}
}
