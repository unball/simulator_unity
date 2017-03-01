using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuOvermind : MonoBehaviour {

    public Dropdown allies;
    public Dropdown enemies;

    public void StartSimulation() {
        PlayerPrefs.SetInt("AlliedRobotAmount", allies.value);
        PlayerPrefs.SetInt("EnemyRobotAmount", enemies.value);
        PlayerPrefs.SetInt("GUIMode", 0);
        SceneManager.LoadScene("Simulation");
    }

    public void StartGUI() {
        PlayerPrefs.SetInt("AlliedRobotAmount", allies.value);
        PlayerPrefs.SetInt("EnemyRobotAmount", 0);
        PlayerPrefs.SetInt("GUIMode", 1);
        SceneManager.LoadScene("Simulation");
    }
}
