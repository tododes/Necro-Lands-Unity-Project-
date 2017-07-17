using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScriptableObjectFactory : MonoBehaviour {

    [MenuItem("Assets/Create/Talent Database")]
    public static void CreateAsset(){
        TalentDatabase instance = ScriptableObject.CreateInstance<TalentDatabase>();
        AssetDatabase.CreateAsset(instance, "Assets/Scripts/Scriptable Objects/Talent Database.asset");
        AssetDatabase.SaveAssets();
    }

}
