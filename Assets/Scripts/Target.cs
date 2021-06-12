using System;
using UnityEngine;

public class Target : MonoBehaviour {
    private GameplayManager gameplayManager;
    
    private void Start() {
        gameplayManager = FindObjectOfType<GameplayManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("LevelObjective")) {
            gameplayManager.Win();
        }
    }
}
