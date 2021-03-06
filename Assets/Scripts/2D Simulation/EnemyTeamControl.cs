﻿using System;
using UnityEngine;

public class EnemyTeamControl : MonoBehaviour {

    private TeamManager enemyTeam;

    void Start() {
        enemyTeam = GetComponent<TeamManager>();
        if (SimulationDataRetriever.instance.simulationMode == SimulationMode.GUI)
            this.enabled = false;
    }

    void FixedUpdate() {
        for (int i = 0; i < SimulationDataRetriever.instance.enemyRobotAmount; ++i)
            UpdateRobotSpeeds(i);
    }

    private void UpdateRobotSpeeds(int robotId) {
        enemyTeam.robotBodyList[robotId].GetComponent<RobotVelocityControl>().
            linearVelocity = VerticalAxis(robotId) * 2.5f;
        enemyTeam.robotBodyList[robotId].GetComponent<RobotVelocityControl>().
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
}
