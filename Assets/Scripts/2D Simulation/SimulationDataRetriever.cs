using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationDataRetriever : MonoBehaviour {

	public static SimulationDataRetriever instance { get; set; }

    public int alliedRobotAmount = 3;
    public int opponentRobotAmount = 3;
    public string allySide = "Left";

    public int GetAlliedRobotAmount() {
        return alliedRobotAmount;
    }

    public int GetOpponentRobotAmount() {
        return opponentRobotAmount;
    }

    public string GetAllySide() {
        return allySide;
    }

    void Awake() {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("[SimulationDataRetriever]Awake: multiple instances of singleton");
    }
}
