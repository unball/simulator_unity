using UnityEngine;

public class SimulationDataRetriever : MonoBehaviour {

    public static SimulationDataRetriever instance { get; set; }

    public int alliedRobotAmount { get; private set; }
    public int enemyRobotAmount { get; private set; }
    public SimulationMode simulationMode { get; private set; }
    public PauseMode pauseMode { get; private set; }
    public PublishingTopic publishingTopic { get; private set; }

    void Awake() {
        SetupSingleton();
        LoadRobotAmount();
        LoadSimulationMode();
        LoadPauseBehaviour();
        LoadPublishingTopic();
    }

    private void SetupSingleton() {
        if (instance != null)
            Debug.LogError("[SimulationDataRetriever]Awake: multiple instances of singleton");
        instance = this;
    }

    private void LoadRobotAmount() {
        if (PlayerPrefs.HasKey("AlliedRobotAmount"))
            alliedRobotAmount = PlayerPrefs.GetInt("AlliedRobotAmount");
        else
            alliedRobotAmount = 3;
        if(PlayerPrefs.HasKey("EnemyRobotAmount"))
            enemyRobotAmount = PlayerPrefs.GetInt("EnemyRobotAmount");
        else
            enemyRobotAmount = 3;
    }

    private void LoadSimulationMode() {
        int isOnGUIMode = PlayerPrefs.GetInt("GUIMode");
        simulationMode = isOnGUIMode == 0 ? SimulationMode.SIMULATION : SimulationMode.GUI;
    }

    private void LoadPauseBehaviour() {
        int pauseMode = PlayerPrefs.GetInt("PauseBehaviour");
        this.pauseMode = pauseMode == 0 ? PauseMode.MESSAGE_ONLY : PauseMode.FORCE_STOP;
    }

    private void LoadPublishingTopic() {
        int publishingTopic = PlayerPrefs.GetInt("PublishingTopic");
        if (publishingTopic == 0)
            this.publishingTopic = PublishingTopic.MEASUREMENT;
        else
            this.publishingTopic = PublishingTopic.VISION;
    }
}

public enum SimulationMode {
    SIMULATION,
    GUI
}

public enum PauseMode {
    MESSAGE_ONLY,
    FORCE_STOP
}

public enum PublishingTopic {
    MEASUREMENT,
    VISION
}
