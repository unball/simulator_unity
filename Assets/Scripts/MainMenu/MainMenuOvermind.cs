using UnityEngine;
using System.Collections;

public class MainMenuOvermind : MonoBehaviour {

    private ConnectionTest ct;

    IEnumerator Start() {
        ct = GetComponent<ConnectionTest>();
        yield return StartCoroutine(ct.TestConnection());
        if (ct.connectionSucceeded)
            MenuLogPanel.instance.ShowMessage("Connected to rosbridge.");
        else
            MenuLogPanel.instance.ShowMessage(ct.errorMessage +
                " Make sure rosbridge server is running.");
    }
}
