﻿using UnityEngine;
using UnityEngine.UI;

public class DropdownOptionSave : MonoBehaviour {

    public int defaultValue;
    public string playerPrefsKey;

    private Dropdown dropdown;

	void Start () {
        dropdown = GetComponent<Dropdown>();
        if (PlayerPrefs.HasKey(playerPrefsKey))
            dropdown.value = PlayerPrefs.GetInt(playerPrefsKey);
        else
            dropdown.value = defaultValue;
	}

    void OnDestroy() {
        PlayerPrefs.SetInt(playerPrefsKey, dropdown.value);
    }
}
