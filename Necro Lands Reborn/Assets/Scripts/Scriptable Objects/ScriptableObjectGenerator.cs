using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScriptableObjectGenerator : MonoBehaviour {

    [MenuItem("Assets/Create/Inventory Data")]
    public static void CreateInventoryData()
    {
        InventoryData id = ScriptableObject.CreateInstance<InventoryData>();
        AssetDatabase.CreateAsset(id, "Assets/Scripts/Scriptable Objects/InventoryData.asset");
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Assets/Create/Player Data")]
    public static void CreatePlayerData()
    {
        PlayerData pd = ScriptableObject.CreateInstance<PlayerData>();
        AssetDatabase.CreateAsset(pd, "Assets/Scripts/Scriptable Objects/PlayerData.asset");
        AssetDatabase.SaveAssets();
    }

    [MenuItem("Assets/Create/Settings Data")]
    public static void CreateSettingsData()
    {
        SettingsData sd = ScriptableObject.CreateInstance<SettingsData>();
        AssetDatabase.CreateAsset(sd, "Assets/Scripts/Scriptable Objects/SettingsData.asset");
        AssetDatabase.SaveAssets();
    }
}
