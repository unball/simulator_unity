using UnityEngine;

public class SimulationDataRetriever : MonoBehaviour {

	public static SimulationDataRetriever instance { get; set; }

    public int alliedRobotAmount = 3;
    public int enemyRobotAmount = 3;

    public int GetAlliedRobotAmount() {
        return alliedRobotAmount;
    }

    public int GetOpponentRobotAmount() {
        return enemyRobotAmount;
    }

    void Awake() {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("[SimulationDataRetriever]Awake: multiple instances of singleton");
    }
}
