﻿using UnityEngine;

public class Ball : MonoBehaviour {

    static public Ball instance { get; private set; }

    private bool isClicked;
    private Vector2 mouseOffset;

    void Awake() {
        if (instance)
            Debug.LogError("[Ball]Awake: Multiple instances of singleton");
        instance = this;
    }

    void Start() {
        if (SimulationDataRetriever.instance.simulationMode == SimulationMode.GUI)
            SetBallGUIMode();
    }

    void SetBallGUIMode() {
        if (SimulationDataRetriever.instance.ballBehaviour == BallGUIBehaviour.PLOT)
            GetComponent<CircleCollider2D>().enabled = false;
    }

    void Update() {
        CheckInput();
        if (Pause.instance.isPaused)
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
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
