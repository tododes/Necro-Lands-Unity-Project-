using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SkillTreeManager : MonoBehaviour {

    private const string skillTreePath = "/SkillTreeData.data";
    private StringBuilder sb;
    private BinaryFormatter bf;
    [SerializeField] private SkillTreeController[] controllers;
    [SerializeField] private TDictionary<string, string[]> skillTreeData;
    //[SerializeField] private PlayerData pData;

    // Use this for initialization
    void Start () {
        sb = new StringBuilder();
        bf = new BinaryFormatter();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Load(){
        FileStream fs = File.Open(Application.persistentDataPath + skillTreePath, FileMode.Open);
        skillTreeData = (TDictionary<string, string[]>) bf.Deserialize(fs);
        string N = LoadPlayerName();
        for (int i = 0; i < controllers.Length; i++){
            controllers[i].code = skillTreeData.ValueOf(N)[i];
            controllers[i].MapSkillTree();
        }
    }

    public void Save(){
        string[] ss = new string[controllers.Length];
        for (int i = 0; i < controllers.Length; i++){
            ss[i] = controllers[i].code;
        }
        string pName = LoadPlayerName();
        skillTreeData.Add(pName, ss);
        FileStream fs = File.Create(Application.persistentDataPath + skillTreePath);
        bf.Serialize(fs, skillTreeData);
        fs.Close();
    }

    private string LoadPlayerName(){
        FileStream fs = File.Open(Application.persistentDataPath + "/PlayerData.data", FileMode.Open);
        PlayerData pd = (PlayerData) bf.Deserialize(fs);
        return pd.Name;
    }
}
