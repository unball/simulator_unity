using UnityEngine;
using System.Collections;
using System;

public class ROSSubscriber : MonoBehaviour {

    private WebSocket socket;

    IEnumerator Start() {
        socket = new WebSocket(new Uri("ws://localhost:9090"));
        yield return StartCoroutine(socket.Connect());
    }

    void OnDestroy() {
        socket.Close();
    }
}
