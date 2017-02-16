using System;
using UnityEngine;

public class OfflineTeamControl : MonoBehaviour {

    private TeamManager alliedTeam;

    void Start() {
        if (ConnectionMode.IsOnline())
            this.enabled = false;
        alliedTeam = GetComponent<TeamManager>();
    }

    void FixedUpdate() {
        for (int i = 0; i < SimulationDataRetriever.instance.alliedRobotAmount; ++i)
            UpdateRobotSpeeds(i);
    }

    private void UpdateRobotSpeeds(int robotId) {
        alliedTeam.robotBodyList[robotId].GetComponent<RobotVelocityControl>().
            linearVelocity = VerticalAxis(robotId) * 2.5f;
        alliedTeam.robotBodyList[robotId].GetComponent<RobotVelocityControl>().
            angularVelocity = HorizontalAxis(robotId) * 100f;
    }

    private int VerticalAxis(int robotId) {
        if (robotId == 0)
            return GetKey(KeyCode.W) - GetKey(KeyCode.S);
        if (robotId == 1)
            return GetKey(KeyCode.T) - GetKey(KeyCode.G);
        if (robotId == 2)
            return GetKey(KeyCode.I) - GetKey(KeyCode.K);
        return 0;
    }

    private int HorizontalAxis(int robotId) {
        if (robotId == 0)
            return GetKey(KeyCode.A) - GetKey(KeyCode.D);
        if (robotId == 1)
            return GetKey(KeyCode.F) - GetKey(KeyCode.H);
        if (robotId == 2)
            return GetKey(KeyCode.J) - GetKey(KeyCode.L);
        return 0;
    }

    private int GetKey(KeyCode key) {
        return Input.GetKey(key) ? 1 : 0;
    }

    // private void ReceiveMessage(string message) {
    //     JSONObject msgJson = new JSONObject(message);
    //     JSONObject vels = new JSONObject(msgJson["msg"].Print());
    //     JSONObject lin_vel_arr = vels["linear_vel"];
    //     JSONObject ang_vel_arr = vels["angular_vel"];
    //     for (int i = 0; i < SimulationDataRetriever.instance.alliedRobotAmount; ++i) {
    //         alliedTeam.robotBodyList[i].GetComponent<RobotVelocityControl>().
    //             linearVelocity = lin_vel_arr[i].n * 10f;
    //         alliedTeam.robotBodyList[i].GetComponent<RobotVelocityControl>().
    //             angularVelocity = ang_vel_arr[i].n;
    //     }
    // }
}
