using UnityEngine;

public class RobotPauseUI : MonoBehaviour {

    public GameObject robotBody;

    private bool isClicked;
    private Vector2 mouseOffset;

	void Update() {
        if (Pause.instance.isPaused) {
            ShowMovementUI();
            CheckInput();
        }
        else
            HideMovementUI();
    }

    private void ShowMovementUI() {
        // Stuff here
    }

    private void HideMovementUI() {
        // Stuff here
    }

    private void CheckInput() {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0)) {
            isClicked = robotBody.GetComponent<BoxCollider2D>().OverlapPoint(mousePosition);
            mouseOffset = mousePosition - (Vector2)robotBody.transform.position;
        }
        if (Input.GetMouseButtonUp(0))
            isClicked = false;
        if (isClicked)
            robotBody.GetComponent<Rigidbody2D>().MovePosition(mousePosition - mouseOffset);
    }
}
