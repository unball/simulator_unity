using System;
using UnityEngine;

public class AlliedTeamControl : MonoBehaviour {

    private ROSSubscriber subscriber;
    private TeamManager alliedTeam;

    void Start() {
        alliedTeam = GetComponent<TeamManager>();
        subscriber = GetComponent<ROSSubscriber>();
        subscriber.callback = ReceiveMessage;
    }

    private void ReceiveMessage(string message) {
        JSONObject msgJson = new JSONObject(message);
        JSONObject vels = new JSONObject(msgJson["msg"].Print());
        JSONObject lin_vel_arr = vels["linear_vel"];
        JSONObject ang_vel_arr = vels["angular_vel"];
        for (int i = 0; i < SimulationDataRetriever.instance.alliedRobotAmount; ++i) {
            alliedTeam.robotBodyList[i].GetComponent<RobotVelocityControl>().
                linearVelocity = lin_vel_arr[i].n * 10f;
            alliedTeam.robotBodyList[i].GetComponent<RobotVelocityControl>().
                angularVelocity = ang_vel_arr[i].n * Mathf.Rad2Deg;
        }
    }
}
