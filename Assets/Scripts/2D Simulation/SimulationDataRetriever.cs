using UnityEngine;

public class SimulationDataRetriever : MonoBehaviour {

	public static SimulationDataRetriever instance { get; set; }

    public int alliedRobotAmount { get; private set; }
    public int enemyRobotAmount { get; private set; }

    void Awake() {
        if (instance == null)
            instance = this;
        else
            Debug.LogError("[SimulationDataRetriever]Awake: multiple instances of singleton");
        alliedRobotAmount = PlayerPrefs.GetInt("AlliedRobotAmount");
        enemyRobotAmount = PlayerPrefs.GetInt("EnemyRobotAmount");
    }
}
