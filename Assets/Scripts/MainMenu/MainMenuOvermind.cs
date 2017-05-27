using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuOvermind : MonoBehaviour {

    public Dropdown allies;
    public Dropdown enemies;
    public Dropdown alliedColor;

    public void StartSimulation() {
        SetPlayerPrefsAndLoadSimulationScene(false);
    }

    public void StartGUI() {
        SetPlayerPrefsAndLoadSimulationScene(true);
    }

    public void OpenConfigMenu() {
        SceneManager.LoadScene("ConfigMenu");
    }

    private void SetPlayerPrefsAndLoadSimulationScene(bool isOnGUIMode) {
        PlayerPrefs.SetInt("AlliedRobotAmount", allies.value);
        PlayerPrefs.SetInt("EnemyRobotAmount", enemies.value);
        PlayerPrefs.SetInt("GUIMode", isOnGUIMode ? 1 : 0);
        PlayerPrefs.SetString("AlliedTeamColor", alliedColor.options[alliedColor.value].text);
        SceneManager.LoadScene("Simulation");
    }
}
