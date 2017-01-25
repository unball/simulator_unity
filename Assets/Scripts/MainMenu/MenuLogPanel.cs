using UnityEngine;
using System.Collections;

public class MenuLogPanel : MonoBehaviour {

    public MenuLogPanel instance { get; private set; }

    void Awake() {
        if (instance != null)
            Debug.LogError("[MenuLogPanel]Awake: Instance already exists");
        else
            instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
