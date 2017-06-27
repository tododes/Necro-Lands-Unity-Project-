using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class ApplicationInitializer : MonoBehaviour {

    [SerializeField] private MissionDatabase missionDB;
    private BinaryFormatter bf;

    void Awake(){
        bf = new BinaryFormatter();
    }

    public void Save(){
        Save(missionDB, "/MissionDatabase.data");
    }

    private void Save(object obj, string path){
        FileStream fs = File.Create(Application.persistentDataPath + path);
        bf.Serialize(fs, obj);
        fs.Close();
    }
}
