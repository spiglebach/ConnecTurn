using UnityEngine;

public class GameplayManager : MonoBehaviour {
    [SerializeField] private Armature currentOrigin;
    [SerializeField] private float turnRate = 1f;
    private readonly Vector3 CounterClockwise = new Vector3(0, 0, 1);
    private readonly Vector3 Clockwise = new Vector3(0, 0, -1);
    
    void Start() {
        currentOrigin.SetConnected();
        transform.position = currentOrigin.transform.position;
    }

    void Update() {
        if (Input.GetKey(KeyCode.A)) {
            currentOrigin.transform.Rotate(CounterClockwise, Time.deltaTime * turnRate);
        }

        if (Input.GetKey(KeyCode.D)) {
            currentOrigin.transform.Rotate(Clockwise, Time.deltaTime * turnRate);
        }
    }

    public void SetArmatureAsOrigin(Armature newOrigin) {
        currentOrigin = newOrigin;
        transform.position = currentOrigin.transform.position;
    }
    
    // todo restart level button
}
