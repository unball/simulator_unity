using System.Collections;
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
        JSONObject robotXposArray = new JSONObject(JSONObject.Type.ARRAY);
        robotXposArray.Add(alliedTeam.robotBodyList[0].position.x * 0.1f);
        robotXposArray.Add(alliedTeam.robotBodyList[1].position.x * 0.1f);
        robotXposArray.Add(alliedTeam.robotBodyList[2].position.x * 0.1f);
        robotXposArray.Add(enemyTeam.robotBodyList[0].position.x * 0.1f);
        robotXposArray.Add(enemyTeam.robotBodyList[1].position.x * 0.1f);
        robotXposArray.Add(enemyTeam.robotBodyList[2].position.x * 0.1f);
        JSONObject robotYposArray = new JSONObject(JSONObject.Type.ARRAY);
        robotYposArray.Add(alliedTeam.robotBodyList[0].position.y * 0.1f);
        robotYposArray.Add(alliedTeam.robotBodyList[1].position.y * 0.1f);
        robotYposArray.Add(alliedTeam.robotBodyList[2].position.y * 0.1f);
        robotYposArray.Add(enemyTeam.robotBodyList[0].position.y * 0.1f);
        robotYposArray.Add(enemyTeam.robotBodyList[1].position.y * 0.1f);
        robotYposArray.Add(enemyTeam.robotBodyList[2].position.y * 0.1f);
        JSONObject robotThetaArray = new JSONObject(JSONObject.Type.ARRAY);
        robotThetaArray.Add(alliedTeam.robotBodyList[0].rotation.eulerAngles.z);
        robotThetaArray.Add(alliedTeam.robotBodyList[1].rotation.eulerAngles.z);
        robotThetaArray.Add(alliedTeam.robotBodyList[2].rotation.eulerAngles.z);
        robotThetaArray.Add(enemyTeam.robotBodyList[0].rotation.eulerAngles.z);
        robotThetaArray.Add(enemyTeam.robotBodyList[1].rotation.eulerAngles.z);
        robotThetaArray.Add(enemyTeam.robotBodyList[2].rotation.eulerAngles.z);
        measurementMessage.AddField("x", robotXposArray);
        measurementMessage.AddField("y", robotYposArray);
        measurementMessage.AddField("th", robotThetaArray);
        measurementMessage.AddField("ball_x", ball.transform.position.x * 0.1f);
        measurementMessage.AddField("ball_y", ball.transform.position.y * 0.1f);
        publisher.PublishMessage(measurementMessage);
        if (publisher.error != null)
            Debug.LogError(publisher.error);
    }
}
