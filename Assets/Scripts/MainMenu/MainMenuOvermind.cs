using UnityEngine;
using System.Collections;

public class MainMenuOvermind : MonoBehaviour {

    private ConnectionTest ct;

    IEnumerator Start() {
        ct = GetComponent<ConnectionTest>();
        yield return StartCoroutine(ct.TestConnection());
        if (ct.connectionSucceeded)
            Application.LoadLevel("Simulation");
        else
            MenuLogPanel.instance.ShowMessage(ct.errorMessage +
                " Make sure rosbridge server is running.");
    }
}
