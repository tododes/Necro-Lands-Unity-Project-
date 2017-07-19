using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScriptableObjectFactory : MonoBehaviour {

    [MenuItem("Assets/Create/Scene Tree")]
    public static void CreateAsset(){
        SceneTree instance = ScriptableObject.CreateInstance<SceneTree>();
        AssetDatabase.CreateAsset(instance, "Assets/Scripts/Scriptable Objects/Scene Tree.asset");
        AssetDatabase.SaveAssets();
    }

}
