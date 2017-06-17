using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SkillTreeManager : MonoBehaviour {

    private StringBuilder sb;
    private BinaryFormatter bf;
    [SerializeField] private SkillTreeController[] controllers;
    [SerializeField] private TDictionary<string, string[]> skillTreeData;
    [SerializeField] private PlayerData pData;

    // Use this for initialization
    void Start () {
        sb = new StringBuilder();
        bf = new BinaryFormatter();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Save(string path){
        string[] ss = new string[controllers.Length];
        for (int i = 0; i < controllers.Length; i++){
            ss[i] = controllers[i].code;
        }
        skillTreeData.Add(pData.Name, ss);
        FileStream fs = File.Create("/SkillTreeData.data");
        bf.Serialize(fs, skillTreeData);
        fs.Close();
    }
}
