using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ScriptableObjectFactory : MonoBehaviour {

    [MenuItem("Assets/Create/Player Skill Database")]
    public static void CreateAsset(){
        PlayerSkillDatabase instance = ScriptableObject.CreateInstance<PlayerSkillDatabase>();
        AssetDatabase.CreateAsset(instance, "Assets/Scripts/Scriptable Objects/Player Skill Database.asset");
        AssetDatabase.SaveAssets();
    }

}
