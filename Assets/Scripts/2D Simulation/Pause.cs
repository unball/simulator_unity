using UnityEngine;
using System.Collections;
using System;

public class Pause : MonoBehaviour {

    public ROSPublisher keyboardMessagePublisher;

	public static Pause instance { get; private set; }

    public bool isPaused { get; private set; }

    public void PauseGame() {
        isPaused = true;
        PublishKeyboardMessage('p');
    }

    public void ResumeGame() {
        isPaused = false;
        PublishKeyboardMessage('r');
    }

    void Awake() {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("[Pause]Awake: multiple instances of singleton");
        isPaused = false;
    }

    private void PublishKeyboardMessage(char key) {
        JSONObject msg = new JSONObject(JSONObject.Type.OBJECT);
        msg.AddField("key", key);
        keyboardMessagePublisher.PublishMessage(msg);
        if (keyboardMessagePublisher.error != null)
            Debug.LogError(keyboardMessagePublisher.error);
    }
}
