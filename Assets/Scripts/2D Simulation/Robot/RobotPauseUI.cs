using UnityEngine;

public class RobotPauseUI : MonoBehaviour {

    public GameObject robotBody;
    public GameObject RotationArrow;

    private bool isClicked;
    private Vector2 mouseOffset;

    void Start() {
        if (SimulationDataRetriever.instance.simulationMode == SimulationMode.GUI)
            gameObject.SetActive(false);
    }

	void Update() {
        if (Pause.instance.isPaused) {
            ShowMovementUI();
            CheckInput();
        }
        else
            HideMovementUI();
    }

    private void ShowMovementUI() {
        RotationArrow.SetActive(true);
    }

    private void HideMovementUI() {
        RotationArrow.SetActive(false);
    }

    private void CheckInput() {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0)) {
            isClicked = robotBody.GetComponent<Collider2D>().OverlapPoint(mousePosition);
            mouseOffset = mousePosition - (Vector2)robotBody.transform.position;
        }
        if (Input.GetMouseButtonUp(0))
            isClicked = false;
        if (isClicked)
            robotBody.GetComponent<Rigidbody2D>().MovePosition(mousePosition - mouseOffset);
    }
}
