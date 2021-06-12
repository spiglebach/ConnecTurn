using UnityEngine;

public class GameplayManager : MonoBehaviour {
    [SerializeField] private Armature currentOrigin;
    [SerializeField] private float turnRate = 1f;
    private readonly Vector3 CounterClockwise = new Vector3(0, 0, 1);
    private readonly Vector3 Clockwise = new Vector3(0, 0, -1);
    [SerializeField] private GameObject winOverlay;
    private bool playerWon;
    
    void Start() {
        currentOrigin.SetConnected();
        transform.position = currentOrigin.transform.position;
        winOverlay.SetActive(false);
    }

    void Update() {
        if (playerWon) {
            currentOrigin.transform.Rotate(Clockwise, Time.deltaTime * turnRate);
        }
        if (Input.GetKey(KeyCode.A)) {
            currentOrigin.transform.Rotate(CounterClockwise, Time.deltaTime * turnRate);
        }

        if (Input.GetKey(KeyCode.D)) {
            currentOrigin.transform.Rotate(Clockwise, Time.deltaTime * turnRate);
        }
    }

    public void SetArmatureAsOrigin(Armature newOrigin) {
        currentOrigin.transform.SetParent(newOrigin.transform);
        currentOrigin = newOrigin;
    }

    public void Win() {
        if (playerWon) {
            return;
        }
        playerWon = true;
        winOverlay.SetActive(true);
    }
}
