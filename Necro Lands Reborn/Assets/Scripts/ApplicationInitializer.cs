using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class ApplicationInitializer : MonoBehaviour {

    public static ApplicationInitializer singleton;

    [SerializeField] private List<MissionDatabase> missionDB;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private InventoryData inventoryData;
    [SerializeField] private Chrono loginData;
    [SerializeField] private Mission missionData;
    [SerializeField] private List<int> talentTreeNodesStatus;

    [SerializeField] private SceneTree sceneTree;
    //[SerializeField] private PlayerTalentList pTalentList;

    private BinaryFormatter bf;

    void Awake(){
        singleton = this;
        bf = new BinaryFormatter();
        sceneTree.OnStartApplication();
        //playerData = Load<PlayerData>(SaveKey.PLAYERDATA_KEY);
    }

    void Start(){
        
    }

    public PlayerData getPlayerData() { return playerData; }
    public void setPlayerData(PlayerData pd) { playerData = pd; }

    public void Save(){
        Save<List<MissionDatabase>>(missionDB, SaveKey.MISSIONDATABASE_KEY);
        Save<PlayerData>(playerData, SaveKey.PLAYERDATA_KEY);
        Save<InventoryData>(inventoryData, SaveKey.PLAYERDATA_KEY);
        Save<Chrono>(loginData, SaveKey.PLAYERDATA_KEY);
        Save<Mission>(missionData, SaveKey.PLAYERDATA_KEY);
        Save<List<int>>(talentTreeNodesStatus, SaveKey.TALENTTREEDATA_KEY);
        //Save<SkillDatabase>(skillDB, SaveKey.SKILLDATABASE_KEY);
    }

    private void Save<T>(T obj, string path){
        FileStream fs = File.Create(Application.persistentDataPath + path);
        bf.Serialize(fs, obj);
        fs.Close();
    }

    private T Load<T>(string path){
        FileStream fs = File.Open(Application.persistentDataPath + path, FileMode.Open);
        return (T) bf.Deserialize(fs);
    }

    public void setTalentStatusData(List<int> data) { talentTreeNodesStatus = data; }
}
