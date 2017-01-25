using UnityEngine;
using System.Collections;
using System;

public class ConnectionTest : MonoBehaviour {

    public bool connectionSucceeded { get; private set; }
    public string errorMessage { get; private set; }

    public IEnumerator TestConnection() {
        var socket = new WebSocket(new Uri("ws://localhost:9090"));
        yield return StartCoroutine(socket.Connect());
        if (socket.error != null) {
            errorMessage = socket.error;
            connectionSucceeded = false;
        }
        else {
            connectionSucceeded = true;
        }
        socket.Close();
    }
}
