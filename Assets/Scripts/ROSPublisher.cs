using UnityEngine;
using System.Collections;
using System;

public class ROSPublisher : MonoBehaviour {

    public string topic;
    public string messageType;

    public string error { get; private set; }

    private WebSocket socket;

    public void PublishMessage(JSONObject jsonMessage) {
        JSONObject pub = new JSONObject(JSONObject.Type.OBJECT);
        pub.AddField("op", "publish");
        pub.AddField("topic", topic);
        pub.AddField("msg", jsonMessage);
        socket.SendString(pub.Print());
        error = socket.error;
    }

    IEnumerator Start() {
        socket = new WebSocket(new Uri("ws://localhost:9090"));
        yield return StartCoroutine(socket.Connect());
        JSONObject adv = new JSONObject(JSONObject.Type.OBJECT);
        adv.AddField("op", "advertise");
        adv.AddField("topic", topic);
        adv.AddField("type", messageType);
        socket.SendString(adv.Print());
        if (socket.error != null)
            Debug.LogError ("Error: "+socket.error);
    }

    void OnDestroy() {
        JSONObject unadv = new JSONObject(JSONObject.Type.OBJECT);
        unadv.AddField("op", "unadvertise");
        unadv.AddField("topic", topic);
        socket.SendString(unadv.Print());
        socket.Close();
    }
}
