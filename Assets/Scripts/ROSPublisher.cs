using UnityEngine;
using System.Collections;
using System;

public class ROSPublisher : MonoBehaviour {

    public string topic;
    public string message_type;

    private WebSocket socket;

    IEnumerator Start() {
        socket = new WebSocket(new Uri("ws://localhost:9090"));
        yield return StartCoroutine(socket.Connect());
        AdvertiseClass adv = new AdvertiseClass(topic, message_type);
        socket.SendString(JsonUtility.ToJson(adv));
        if (socket.error != null)
            Debug.LogError ("Error: "+socket.error);
    }

    void OnDestroy() {
        UnadvertiseClass unadv = new UnadvertiseClass(topic);
        socket.SendString(JsonUtility.ToJson(unadv));
        socket.Close();
    }
}

[Serializable]
public class AdvertiseClass {
    public string op = "advertise";
    public string topic;
    public string type;

    public AdvertiseClass(string topic, string message_type) {
        this.topic = topic;
        type = message_type;
    }
}

[Serializable]
public class UnadvertiseClass {
    public string op = "unadvertise";
    public string topic;

    public UnadvertiseClass(string topic) {
        this.topic = topic;
    }
}
