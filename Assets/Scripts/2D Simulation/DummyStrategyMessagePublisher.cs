using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyStrategyMessagePublisher : MonoBehaviour {

    public ROSPublisher publisher;

    void FixedUpdate () {
        if (Time.timeSinceLevelLoad < 0.5f)
            return;
        JSONObject strategyMessage = new JSONObject(JSONObject.Type.OBJECT);
        strategyMessage.AddField("lin_vel", MakeLinVelArray());
        strategyMessage.AddField("ang_vel", MakeAngVelArray());
        publisher.PublishMessage(strategyMessage);
        if (publisher.error != null)
            Debug.LogError(publisher.error);
    }

    private JSONObject MakeLinVelArray() {
        JSONObject linVelArray = new JSONObject(JSONObject.Type.ARRAY);
        for (int i = 0; i < 6; ++i)
            linVelArray.Add(Random.Range(0f, 0.02f));
        return linVelArray;
    }

    private JSONObject MakeAngVelArray() {
        JSONObject angVelArray = new JSONObject(JSONObject.Type.ARRAY);
        for (int i = 0; i < 6; ++i)
            angVelArray.Add(Random.Range(-10f, 40f));
        return angVelArray;
    }
}
