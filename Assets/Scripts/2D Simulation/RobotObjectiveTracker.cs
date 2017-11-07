using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotObjectiveTracker : MonoBehaviour {

    private List<GameObject> objectiveObjects = new List<GameObject>();
    private ROSSubscriber subscriber;

    void Start() {
        subscriber = GetComponent<ROSSubscriber>();
        subscriber.callback = ReceiveStrategyMessage;
        ReadObjectiveObjectList();
    }

    private void ReadObjectiveObjectList() {
        foreach (Transform child in transform)
            objectiveObjects.Add(child.gameObject);
    }

    private void ReceiveStrategyMessage(string message) {
        EnableObjectiveObjects();
        JSONObject msgJson = new JSONObject(message);
        JSONObject info = new JSONObject(msgJson["msg"].Print());
        JSONObject xPosArr = info["x"];
        JSONObject yPosArr = info["y"];
        for (int i = 0; i < SimulationDataRetriever.instance.alliedRobotAmount; ++i) {
            objectiveObjects[i].transform.position =
                new Vector2(xPosArr[i].n * 10f, yPosArr[i].n * 10f);
        }
    }

    private void EnableObjectiveObjects() {
        for (int i = 0; i < SimulationDataRetriever.instance.alliedRobotAmount; ++i)
            objectiveObjects[i].SetActive(true);
    }
}
