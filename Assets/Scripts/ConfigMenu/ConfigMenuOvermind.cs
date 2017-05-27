using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfigMenuOvermind : MonoBehaviour {

    public void ReturnToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
