using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotObjectiveTracker : MonoBehaviour {

    public TeamManager alliedTeam;
    public List<GameObject> objectiveObjects;

    private ROSSubscriber subscriber;

    void Start() {
        subscriber = GetComponent<ROSSubscriber>();
        subscriber.callback = ReceiveRobotObjectives;
        EnableObjectiveObjects();
    }

    private void EnableObjectiveObjects() {
        for (int i = 0; i < SimulationDataRetriever.instance.alliedRobotAmount; ++i)
            objectiveObjects[i].SetActive(true);
    }

    private void ReceiveRobotObjectives(string message) {
        JSONObject msgJson = new JSONObject(message);
        JSONObject info = new JSONObject(msgJson["msg"].Print());
        JSONObject xPosArr = info["x"];
        JSONObject yPosArr = info["y"];
        for (int i = 0; i < SimulationDataRetriever.instance.alliedRobotAmount; ++i) {
            var objectiveAsGlobal = ConvertRelativeToGlobalPoint(i, xPosArr[i].n * 10f, yPosArr[i].n * 10f);
            objectiveObjects[i].transform.position = objectiveAsGlobal;
        }
    }

    private Vector2 ConvertRelativeToGlobalPoint(int robot_index, float xPos, float yPos) {
        Transform currentRobot = alliedTeam.robotBodyList[robot_index];
        float robotTheta = currentRobot.eulerAngles.z;
        Vector2 objectivePos = new Vector2(xPos, yPos);
        objectivePos = RotatePoint(objectivePos, 270);
        objectivePos = RotatePoint(objectivePos, robotTheta);
        objectivePos = (Vector2)currentRobot.position + objectivePos;
        return objectivePos;
    }

    private Vector2 RotatePoint(Vector2 point, float theta) {
        Vector2 result = point;
        result.x = result.x * Mathf.Cos(theta * Mathf.Deg2Rad) -
                   result.y * Mathf.Sin(theta * Mathf.Deg2Rad);
        result.y = result.x * Mathf.Sin(theta * Mathf.Deg2Rad) +
                   result.y * Mathf.Cos(theta * Mathf.Deg2Rad);
        return result;
    }
}
