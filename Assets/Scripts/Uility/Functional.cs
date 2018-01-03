using System;
using UnityEngine;

public static class Functional {

    public class Ticker : Singleton<Ticker> {
        public event Action updated;
        void Start() {

        }

        void Update() {
            if (updated != null) {
                updated();
            }
        }
    }

    public static Action Debounce(Action method, float interval) {
        float elapsed = interval;
        Ticker.instance.updated += () => {
            elapsed += Time.deltaTime; 
        };

        return () => {
            if (elapsed >= interval) {
                method();
                elapsed = 0;
            }
        };
    }
}