﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeasurementSystem : MonoBehaviour {

    public ROSPublisher publisher;
    public GameObject ball;
    public TeamManager alliedTeam;
    public TeamManager enemyTeam;

    void FixedUpdate () {
        if (Time.timeSinceLevelLoad < 0.5f)
            return;
        JSONObject measurementMessage = new JSONObject(JSONObject.Type.OBJECT);
        measurementMessage.AddField("x", MakeXPosArray());
        measurementMessage.AddField("y", MakeYPosArray());
        measurementMessage.AddField("th", MakeThetaArray());
        measurementMessage.AddField("ball_x", ball.transform.position.x * 0.1f);
        measurementMessage.AddField("ball_y", ball.transform.position.y * 0.1f);
        publisher.PublishMessage(measurementMessage);
        if (publisher.error != null)
            Debug.LogError(publisher.error);
    }

    private JSONObject MakeXPosArray() {
        JSONObject robotXposArray = new JSONObject(JSONObject.Type.ARRAY);
        int i;
        for (i = 0; i < SimulationDataRetriever.instance.GetAlliedRobotAmount(); ++i)
            robotXposArray.Add(alliedTeam.robotBodyList[i].position.x * 0.1f);
        for (; i < 3; ++i)
            robotXposArray.Add(0f);
        for (i = 0; i < SimulationDataRetriever.instance.GetOpponentRobotAmount(); ++i)
            robotXposArray.Add(enemyTeam.robotBodyList[i].position.x * 0.1f);
        for (; i < 3; ++i)
            robotXposArray.Add(0f);
        return robotXposArray;
    }

    private JSONObject MakeYPosArray() {
        JSONObject robotYposArray = new JSONObject(JSONObject.Type.ARRAY);
        int i;
        for (i = 0; i < SimulationDataRetriever.instance.GetAlliedRobotAmount(); ++i)
            robotYposArray.Add(alliedTeam.robotBodyList[i].position.y * 0.1f);
        for (; i < 3; ++i)
            robotYposArray.Add(0f);
        for (i = 0; i < SimulationDataRetriever.instance.GetOpponentRobotAmount(); ++i)
            robotYposArray.Add(enemyTeam.robotBodyList[i].position.y * 0.1f);
        for (; i < 3; ++i)
            robotYposArray.Add(0f);
        return robotYposArray;
    }

    private JSONObject MakeThetaArray() {
        JSONObject robotThetaArray = new JSONObject(JSONObject.Type.ARRAY);
        int i;
        for (i = 0; i < SimulationDataRetriever.instance.GetAlliedRobotAmount(); ++i)
            robotThetaArray.Add(alliedTeam.robotBodyList[i].rotation.eulerAngles.z);
        for (; i < 3; ++i)
            robotThetaArray.Add(0f);
        for (i = 0; i < SimulationDataRetriever.instance.GetOpponentRobotAmount(); ++i)
            robotThetaArray.Add(enemyTeam.robotBodyList[i].rotation.eulerAngles.z);
        for (; i < 3; ++i)
            robotThetaArray.Add(0f);
        return robotThetaArray;
    }
}
