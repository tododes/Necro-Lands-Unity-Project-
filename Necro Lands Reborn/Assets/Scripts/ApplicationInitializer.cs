using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class ApplicationInitializer : MonoBehaviour {

    [SerializeField] private MissionDatabase missionDB;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private InventoryData inventoryData;
    [SerializeField] private Chrono loginData;
    [SerializeField] private Mission missionData;
    [SerializeField] private SkillDatabase skillDB;
    //[SerializeField] private PlayerTalentList pTalentList;

    private BinaryFormatter bf;

    void Awake(){
        bf = new BinaryFormatter();
    }

    public void Save(){
        Save<MissionDatabase>(missionDB, SaveKey.MISSIONDATABASE_KEY);
        Save<PlayerData>(playerData, SaveKey.PLAYERDATA_KEY);
        Save<InventoryData>(inventoryData, SaveKey.PLAYERDATA_KEY);
        Save<Chrono>(loginData, SaveKey.PLAYERDATA_KEY);
        Save<Mission>(missionData, SaveKey.PLAYERDATA_KEY);
        Save<SkillDatabase>(skillDB, SaveKey.SKILLDATABASE_KEY);
    }

    private void Save<T>(T obj, string path){
        if (!File.Exists(path)) {
            FileStream fs = File.Create(Application.persistentDataPath + path);
            bf.Serialize(fs, obj);
            fs.Close();
        }
    }

    private T Load<T>(string path){
        FileStream fs = File.Open(Application.persistentDataPath + path, FileMode.Open);
        return (T) bf.Deserialize(fs);
    }
}
