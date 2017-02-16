using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConnectionMode {

    public static bool IsOffline() {
        if (!PlayerPrefs.HasKey("OfflineMode"))
            SetOnlineMode();
        return PlayerPrefs.GetInt("OfflineMode") == 1;
    }

    public static bool IsOnline() {
        return !IsOffline();
    }

    public static void SetOfflineMode() {
        PlayerPrefs.SetInt("OfflineMode", 1);
    }

    public static void SetOnlineMode() {
        PlayerPrefs.SetInt("OfflineMode", 0);
    }
}
