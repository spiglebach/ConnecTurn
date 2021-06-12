using UnityEngine;

public class Armature : MonoBehaviour {
    private bool connected;
    private GameplayManager gameplayManager;
    [SerializeField] private SpriteRenderer spriteRenderer;

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
        if (unconnectedArmature.IsConnected()) {
            return;
        }
        Debug.Log("absorbed");
        unconnectedArmature.AbsorbAndGiveControl(transform);
    }

    public void SetHingeColor(Color color) {
        spriteRenderer.color = color;
    }

    private void AbsorbAndGiveControl(Transform absorbedTransform) {
        connected = true;
        gameplayManager.SetArmatureAsOrigin(this);
    }

    public void SetConnected() {
        connected = true;
    }

    public bool IsConnected() {
        return connected;
    }
}
