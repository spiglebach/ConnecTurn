using UnityEngine;

public class Armature : MonoBehaviour {
    private bool connected;
    private GameplayManager gameplayManager;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color controllingColor;

    private void Start() {
        gameplayManager = FindObjectOfType<GameplayManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("collision");
        if (!connected) {
            return;
        }
        if (!other.TryGetComponent(out Armature unconnectedArmature)) {
            return;
        }
        unconnectedArmature.AbsorbAndGiveControl(transform);
    }

    public void SetDefaultColor() {
        spriteRenderer.color = defaultColor;
    }

    public void SetControllingColor() {
        spriteRenderer.color = controllingColor;
    }

    private void AbsorbAndGiveControl(Transform absorbedTransform) {
        connected = true;
        gameplayManager.SetArmatureAsOrigin(this);
    }

    public void SetConnected() {
        connected = true;
    }
}
