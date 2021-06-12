using UnityEngine;

public class GameplayManager : MonoBehaviour {
    [SerializeField] private Armature currentOrigin;
    [SerializeField] private float turnRate = 1f;
    private readonly Vector3 CounterClockwise = new Vector3(0, 0, 1);
    private readonly Vector3 Clockwise = new Vector3(0, 0, -1);
    [SerializeField] private GameObject winOverlay;
    private bool playerWon;
    private LevelProgress levelProgress;
    [SerializeField] private GameObject helpCanvas;
    private bool helpEnabled;
    
    void Start() {
        levelProgress = FindObjectOfType<LevelProgress>();
        currentOrigin.SetConnected();
        transform.position = currentOrigin.transform.position;
        winOverlay.SetActive(false);
        helpCanvas.SetActive(false);
    }

    void Update() {
        if (playerWon) {
            currentOrigin.transform.Rotate(Clockwise, Time.deltaTime * turnRate);
            return;
        }

        if (Input.GetKeyDown(KeyCode.H)) {
            helpEnabled = !helpEnabled;
            helpCanvas.SetActive(helpEnabled);
        }
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            currentOrigin.transform.Rotate(CounterClockwise, Time.deltaTime * turnRate);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            currentOrigin.transform.Rotate(Clockwise, Time.deltaTime * turnRate);
        }
    }

    public void SetArmatureAsOrigin(Armature newOrigin) {
        /*if (currentOrigin.TryGetComponent(out CompositeCollider2D oldCollider)) {
            Destroy(oldCollider);
        }
        if (currentOrigin.TryGetComponent(out Rigidbody2D oldRigidbody)) {
            Destroy(oldRigidbody);
        }*/
        currentOrigin.SetDefaultColor();
        newOrigin.SetControllingColor();
        currentOrigin.transform.SetParent(newOrigin.transform);
        currentOrigin = newOrigin;
    }

    public void Win() {
        if (playerWon) {
            return;
        }
        if (levelProgress) {
            levelProgress.LevelComplete();
        }
        playerWon = true;
        winOverlay.SetActive(true);
    }
}
