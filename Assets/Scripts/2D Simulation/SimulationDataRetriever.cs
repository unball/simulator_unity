using UnityEngine;

public class SimulationDataRetriever : MonoBehaviour {

	public static SimulationDataRetriever instance { get; set; }

    public int alliedRobotAmount { get; private set; }
    public int enemyRobotAmount { get; private set; }
    public SimulationMode simulationMode { get; private set; }

    void Awake() {
        SetupSingleton();
        LoadRobotAmount();
        LoadSimulationMode();
    }

    private void SetupSingleton() {
        if (instance != null)
            Debug.LogError("[SimulationDataRetriever]Awake: multiple instances of singleton");
        instance = this;
    }

    private void LoadRobotAmount() {
        alliedRobotAmount = PlayerPrefs.GetInt("AlliedRobotAmount");
        enemyRobotAmount = PlayerPrefs.GetInt("EnemyRobotAmount");
    }

    private void LoadSimulationMode() {
        int isOnGUIMode = PlayerPrefs.GetInt("GUIMode");
        simulationMode = isOnGUIMode == 0 ? SimulationMode.SIMULATION : SimulationMode.GUI;
    }
}

public enum SimulationMode {
    SIMULATION,
    GUI
}
