using System;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour {

    public GameObject baseRobot;
    public bool isAlly = true;
    public Vector2[] initialPosition;

    public List<Transform> robotList { get; private set; }
    public List<Transform> robotBodyList { get; private set; }

    void Start() {
        robotList = new List<Transform>();
        robotBodyList = new List<Transform>();
        if (isAlly)
            GenerateRobots(SimulationDataRetriever.instance.alliedRobotAmount, RobotColorPicker.BlueTeam);
        else
            GenerateRobots(SimulationDataRetriever.instance.enemyRobotAmount, RobotColorPicker.YellowTeam);
    }

    private void GenerateRobots(int robotAmount, Func<int, RobotColor> getColorMethod) {
        for (int i = 0; i < robotAmount; ++i)
            GenerateRobot(i, getColorMethod(i));
    }

    private void GenerateRobot(int robotId, RobotColor robotColor) {
        var newRobot = Instantiate(baseRobot);
        newRobot.name = "Robot " + robotId;
        newRobot.transform.parent = transform;
        newRobot.transform.position = initialPosition[robotId];
        newRobot.GetComponent<RobotColorApplier>().ApplyColor(robotColor);
        newRobot.transform.GetChild(0).GetComponent<RobotLookAtPoint>().LookAt(Ball.instance.transform.position);
        robotList.Add(newRobot.transform);
        robotBodyList.Add(newRobot.transform.GetChild(0));
    }
}
