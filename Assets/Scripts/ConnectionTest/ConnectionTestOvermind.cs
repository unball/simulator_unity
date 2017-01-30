using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ConnectionTestOvermind : MonoBehaviour {

    private ConnectionTest ct;

    IEnumerator Start() {
        ct = GetComponent<ConnectionTest>();
        yield return StartCoroutine(ct.TestConnection());
        if (ct.connectionSucceeded)
            SceneManager.LoadScene("Simulation");
        else
            MenuLogPanel.instance.ShowMessage(ct.errorMessage +
                " Make sure rosbridge server is running.");
    }
}
