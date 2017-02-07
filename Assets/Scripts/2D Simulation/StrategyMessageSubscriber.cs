using System;
using UnityEngine;

public class StrategyMessageSubscriber : MonoBehaviour {

    public ROSSubscriber subscriber;
    public TeamManager alliedTeam;
    public TeamManager enemyTeam;

    void Start() {
        subscriber.callback = ReceiveMessage;
    }

    private void ReceiveMessage(string message) {
        JSONObject msgJson = new JSONObject(message);
        JSONObject vels = new JSONObject(msgJson["msg"].Print());
        JSONObject lin_vel_arr = vels["lin_vel"];
        JSONObject ang_vel_arr = vels["ang_vel"];
        for (int i = 0; i < SimulationDataRetriever.instance.alliedRobotAmount; ++i) {
            alliedTeam.robotBodyList[i].GetComponent<RobotVelocityControl>().
                linearVelocity = lin_vel_arr[i].n * 10f;
            alliedTeam.robotBodyList[i].GetComponent<RobotVelocityControl>().
                angularVelocity = ang_vel_arr[i].n;
        }
        for (int i = 0; i < SimulationDataRetriever.instance.enemyRobotAmount; ++i) {
            enemyTeam.robotBodyList[i].GetComponent<RobotVelocityControl>().
                linearVelocity = lin_vel_arr[i+3].n * 10f;
            enemyTeam.robotBodyList[i].GetComponent<RobotVelocityControl>().
                angularVelocity = ang_vel_arr[i+3].n;
        }
    }
}
