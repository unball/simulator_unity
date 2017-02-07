using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour {

    public void Return() {
        SceneManager.LoadScene("MainMenu");
    }
}
