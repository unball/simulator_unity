using UnityEngine;
using System.Collections;

public class WebSocketInterface : MonoBehaviour {

    public WebSocketInterface instance { get; private set; }

    void Awake() {
        if (instance != null)
            Debug.LogError("[WebSocketInterface]Awake: Instance already exists");
        else
            instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
