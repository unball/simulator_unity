using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuLogPanel : MonoBehaviour {

    public static MenuLogPanel instance { get; private set; }

    void Awake() {
        if (instance != null)
            Debug.LogError("[MenuLogPanel]Awake: Instance already exists");
        else
            instance = this;
    }

    public void ShowMessage(string msg) {
        transform.GetChild(0).GetComponent<Text>().text = msg;
    }
}
