using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	public static Pause instance { get; private set; }

    public bool isPaused { get; private set; }

    public void PauseGame() {
        isPaused = true;
    }

    public void ResumeGame() {
        isPaused = false;
    }

    void Awake() {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("[Pause]Awake: multiple instances of singleton");
        isPaused = false;
    }
}
