using UnityEngine;
using System.Collections;
using System;

public class ROSSubscriber : MonoBehaviour {

    public string topic;
    public string messageType;

    public Action<string> callback { get; set; }
    public string error { get; private set; }

    private WebSocket socket;

    IEnumerator Start() {
        if (ConnectionMode.IsOnline()) {
            socket = new WebSocket(new Uri("ws://localhost:9090"));
            yield return StartCoroutine(socket.Connect());
            JSONObject sub = new JSONObject(JSONObject.Type.OBJECT);
            sub.AddField("op", "subscribe");
            sub.AddField("topic", topic);
            sub.AddField("type", messageType);
            sub.AddField("queue_length", 1);
            socket.SendString(sub.Print());
            if (socket.error != null)
                Debug.LogError ("Error: "+socket.error);
        }
    }

    void FixedUpdate() {
        if (ConnectionMode.IsOnline()) {
            string reply = socket.RecvString();
            error = socket.error;
            if (reply != null && callback != null && error == null)
                callback(reply);
        }
    }

    void OnDestroy() {
        if (ConnectionMode.IsOnline()) {
            JSONObject unsub = new JSONObject(JSONObject.Type.OBJECT);
            unsub.AddField("op", "unsubscribe");
            unsub.AddField("topic", topic);
            socket.SendString(unsub.Print());
            socket.Close();
        }
    }
}
