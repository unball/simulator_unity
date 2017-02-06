using UnityEngine;

public class RobotRotationArrow : MonoBehaviour {

    public GameObject robotBody;
    public Collider2D arrowCollider;

    private bool isClicked;
    private Vector2 mouseOffset;

    void Update() {
        CheckInput();
    }

    private void CheckInput() {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0)) {
            isClicked = arrowCollider.OverlapPoint(mousePosition);
            mouseOffset = mousePosition - (Vector2)transform.position;
        }
        if (Input.GetMouseButtonUp(0))
            isClicked = false;
        if (isClicked)
            RotateRobotWithMousePosition(mousePosition - mouseOffset);
    }

    private void RotateRobotWithMousePosition(Vector2 position) {
        var orientationVector = (position - (Vector2)robotBody.transform.position).normalized;
        float angle = Mathf.Atan2(orientationVector.y, orientationVector.x) * Mathf.Rad2Deg + 90;
        robotBody.GetComponent<Rigidbody2D>().MoveRotation(angle);
    }
}
