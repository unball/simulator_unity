using UnityEngine;
using UnityEngine.UI;

public class InputFieldOptionSave : MonoBehaviour {

    public string defaultValue;
    public string playerPrefsKey;

    private InputField inputField;

    void Start () {
        inputField = GetComponent<InputField>();
        if (PlayerPrefs.HasKey(playerPrefsKey))
            inputField.text = PlayerPrefs.GetString(playerPrefsKey);
        else
            inputField.text = defaultValue;
    }

    void OnDestroy() {
        PlayerPrefs.SetString(playerPrefsKey, inputField.text);
    }
}
