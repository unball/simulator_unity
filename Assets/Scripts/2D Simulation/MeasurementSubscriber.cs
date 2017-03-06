using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeasurementSubscriber : MonoBehaviour {

    public TeamManager alliedTeam;
    public TeamManager enemyTeam;

    private ROSSubscriber subscriber;

    void Start() {
        if (SimulationDataRetriever.instance.simulationMode == SimulationMode.SIMULATION) {
            this.enabled = false;
        }
        else {
            subscriber = GetComponent<ROSSubscriber>();
            subscriber.callback = ReceiveMeasurementSystemMessage;
        }
    }

    private void ReceiveMeasurementSystemMessage(string message) {
        JSONObject msgJson = new JSONObject(message);
        JSONObject info = new JSONObject(msgJson["msg"].Print());
        JSONObject xPosArr = info["x"];
        JSONObject yPosArr = info["y"];
        JSONObject thetaArr = info["th"];
        JSONObject ballX = info["ball_x"];
        JSONObject ballY = info["ball_y"];

        // Read allied robot positions
        for (int i = 0; i < SimulationDataRetriever.instance.alliedRobotAmount; ++i) {
            alliedTeam.robotBodyList[i].GetComponent<Rigidbody2D>().
                MovePosition(new Vector2(xPosArr[i].n * 10f, yPosArr[i].n * 10f));
            alliedTeam.robotBodyList[i].GetComponent<Rigidbody2D>().
                MoveRotation(thetaArr[i].n * Mathf.Rad2Deg);
        }

        // Read enemy robot positions
        for (int i = 0; i < SimulationDataRetriever.instance.enemyRobotAmount; ++i) {
            enemyTeam.robotBodyList[i].GetComponent<Rigidbody2D>().
                MovePosition(new Vector2(xPosArr[i+3].n * 10f, yPosArr[i+3].n * 10f));
            enemyTeam.robotBodyList[i].GetComponent<Rigidbody2D>().
                MoveRotation(thetaArr[i+3].n * Mathf.Rad2Deg);
        }

        Ball.instance.GetComponent<Rigidbody2D>().MovePosition(new Vector2(ballX.n * 10f, ballY.n * 10f));
    }
}
