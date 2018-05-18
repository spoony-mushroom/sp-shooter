using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component {

	public static T instance { 
		get {
			if (instance_ == null) {
				var go = new GameObject();
				instance_ = go.AddComponent<T>();
				go.name = nameof(T);
			}
			return instance_;
		} 
	}
	private static T instance_;

	void Awake() {
		instance_ = this as T;
	}
}
