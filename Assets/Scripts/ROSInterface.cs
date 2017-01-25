using UnityEngine;
using System.Collections;
using System;

public class ROSInterface : MonoBehaviour {

    public ROSInterface instance { get; private set; }
    public string receivedMessage { get; private set; }

    private WebSocket socket = new WebSocket(new Uri("ws://localhost:9090"));
    private bool isConnected;

    void Awake() {
        if (instance != null)
            Debug.LogError("[ROSInterface]Awake: Instance already exists");
        else
            instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void TestConnection() {
        StartCoroutine(_TestConnection());
    }

    private IEnumerator _TestConnection() {
        yield return StartCoroutine(socket.Connect());
        if (socket.error != null)
            Debug.LogError("Error on connection to socket: " + socket.error);
        else
            socket.Close();
    }
}
