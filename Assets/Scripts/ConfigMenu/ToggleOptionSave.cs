using UnityEngine;
using UnityEngine.UI;

public class ToggleOptionSave : MonoBehaviour {

    public string playerPrefsKey;

    private bool defaultValue = true;
    private Toggle toggle;

    void Start () {
        toggle = GetComponent<Toggle>();
        if (PlayerPrefs.HasKey(playerPrefsKey))
            toggle.isOn = PlayerPrefs.GetInt(playerPrefsKey) == 1 ? true : false;
        else
            toggle.isOn = defaultValue;
    }

    void OnDestroy() {
        PlayerPrefs.SetInt(playerPrefsKey, toggle.isOn ? 1 : 0);
    }
}
