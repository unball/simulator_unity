using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeasurementSystem : MonoBehaviour {

    public TeamManager alliedTeam;
    public TeamManager enemyTeam;

    private ROSPublisher publisher;

    void Start() {
        if (SimulationDataRetriever.instance.simulationMode == SimulationMode.GUI) {
            this.enabled = false;
        }
        else {
            publisher = GetComponent<ROSPublisher>();
        }
    }

    void FixedUpdate () {
        if (Time.timeSinceLevelLoad < 0.5f)
            return;
        JSONObject measurementMessage = new JSONObject(JSONObject.Type.OBJECT);
        measurementMessage.AddField("x", MakeXPosArray());
        measurementMessage.AddField("y", MakeYPosArray());
        measurementMessage.AddField("th", MakeThetaArray());
        measurementMessage.AddField("ball_x", Ball.instance.transform.position.x * 0.1f);
        measurementMessage.AddField("ball_y", Ball.instance.transform.position.y * 0.1f);
        publisher.PublishMessage(measurementMessage);
        if (publisher.error != null)
            Debug.LogError(publisher.error);
    }

    private JSONObject MakeXPosArray() {
        JSONObject robotXposArray = new JSONObject(JSONObject.Type.ARRAY);
        int i;
        for (i = 0; i < SimulationDataRetriever.instance.alliedRobotAmount; ++i)
            robotXposArray.Add(alliedTeam.robotBodyList[i].position.x * 0.1f);
        for (; i < 3; ++i)
            robotXposArray.Add(0f);
        for (i = 0; i < SimulationDataRetriever.instance.enemyRobotAmount; ++i)
            robotXposArray.Add(enemyTeam.robotBodyList[i].position.x * 0.1f);
        for (; i < 3; ++i)
            robotXposArray.Add(0f);
        return robotXposArray;
    }

    private JSONObject MakeYPosArray() {
        JSONObject robotYposArray = new JSONObject(JSONObject.Type.ARRAY);
        int i;
        for (i = 0; i < SimulationDataRetriever.instance.alliedRobotAmount; ++i)
            robotYposArray.Add(alliedTeam.robotBodyList[i].position.y * 0.1f);
        for (; i < 3; ++i)
            robotYposArray.Add(0f);
        for (i = 0; i < SimulationDataRetriever.instance.enemyRobotAmount; ++i)
            robotYposArray.Add(enemyTeam.robotBodyList[i].position.y * 0.1f);
        for (; i < 3; ++i)
            robotYposArray.Add(0f);
        return robotYposArray;
    }

    private JSONObject MakeThetaArray() {
        JSONObject robotThetaArray = new JSONObject(JSONObject.Type.ARRAY);
        int i;
        for (i = 0; i < SimulationDataRetriever.instance.alliedRobotAmount; ++i)
            robotThetaArray.Add(alliedTeam.robotBodyList[i].rotation.eulerAngles.z * Mathf.Deg2Rad);
        for (; i < 3; ++i)
            robotThetaArray.Add(0f);
        for (i = 0; i < SimulationDataRetriever.instance.enemyRobotAmount; ++i)
            robotThetaArray.Add(enemyTeam.robotBodyList[i].rotation.eulerAngles.z * Mathf.Deg2Rad);
        for (; i < 3; ++i)
            robotThetaArray.Add(0f);
        return robotThetaArray;
    }
}
