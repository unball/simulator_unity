using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceButtonPauseToggle : MonoBehaviour {

    public GameObject pauseButton;
    public GameObject resumeButton;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
            TogglePause();
    }

    private void TogglePause() {
        if (Pause.instance.isPaused) {
            Pause.instance.ResumeGame();
            resumeButton.SetActive(false);
            pauseButton.SetActive(true);
        }
        else {
            Pause.instance.PauseGame();
            pauseButton.SetActive(false);
            resumeButton.SetActive(true);
        }
    }
}
