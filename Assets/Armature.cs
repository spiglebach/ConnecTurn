using UnityEngine;

public class Armature : MonoBehaviour {
    private bool connected;
    private GameplayManager gameplayManager;

    private void Start() {
        gameplayManager = FindObjectOfType<GameplayManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!connected) {
            return;
        }
        if (!other.TryGetComponent(out Armature unconnectedArmature)) {
            return;
        }
        unconnectedArmature.AbsorbAndGiveControl(transform);
    }

    private void AbsorbAndGiveControl(Transform absorbedTransform) {
        absorbedTransform.SetParent(transform);
        connected = true;
        gameplayManager.SetArmatureAsOrigin(this);
    }

    public void SetConnected() {
        connected = true;
    }
}
