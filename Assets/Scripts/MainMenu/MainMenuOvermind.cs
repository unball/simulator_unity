using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuOvermind : MonoBehaviour {

    public Dropdown allies;
    public Dropdown enemies;

    public void StartSimulation() {
        PlayerPrefs.SetInt("AlliedRobotAmount", allies.value);
        PlayerPrefs.SetInt("EnemyRobotAmount", enemies.value);
        SceneManager.LoadScene("Simulation");
    }
}
