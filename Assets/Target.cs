using UnityEngine;

public class Target : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("LevelObjective")) {
            // todo display win screen
            Debug.Log("win!");
        }
    }
}
