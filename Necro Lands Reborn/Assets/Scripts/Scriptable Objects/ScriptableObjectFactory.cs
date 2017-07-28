using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScriptableObjectFactory : MonoBehaviour {
    [MenuItem("Assets/Create/Scene Tree Node")]
    public static void CreateAsset(){
        SceneTreeNode instance = ScriptableObject.CreateInstance<SceneTreeNode>();
        AssetDatabase.CreateAsset(instance, "Assets/Scripts/Scriptable Objects/Scenes/Skill Shop Node.asset");
        AssetDatabase.SaveAssets();
    }
}
