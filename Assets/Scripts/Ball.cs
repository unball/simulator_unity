using UnityEngine;

public class Ball : MonoBehaviour {

    private bool isClicked;
    private Vector2 mouseOffset;

    void Update() {
        if (Pause.instance.isPaused) {
            CheckInput();
        }
    }

    private void CheckInput() {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0)) {
            isClicked = GetComponent<Collider2D>().OverlapPoint(mousePosition);
            mouseOffset = mousePosition - (Vector2)transform.position;
        }
        if (Input.GetMouseButtonUp(0))
            isClicked = false;
        if (isClicked)
            GetComponent<Rigidbody2D>().MovePosition(mousePosition - mouseOffset);
    }
}
