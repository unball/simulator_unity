using UnityEngine;
using UnityEngine.SceneManagement;

public class GoOnlineButton : MonoBehaviour {

    public void ReturnToConnectionTestScreen() {
        SceneManager.LoadScene("ConnectionTestScreen");
    }

    void Start() {
        if (ConnectionMode.IsOnline())
            gameObject.SetActive(false);
    }
}
