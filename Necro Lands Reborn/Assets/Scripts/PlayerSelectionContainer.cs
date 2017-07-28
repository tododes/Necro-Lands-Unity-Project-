using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerSelectionContainer : TodoBehaviour {

    [SerializeField] private int index;
    [SerializeField] private PlayerAttribute[] attributes;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private InventoryData id;

    private BinaryFormatter bf;
    private FileStream fs;

    public void dec(){
        index--;
        //if (index < 0) index = 3;
        //if (index < -3) index = -3;
    }
    public void inc(){
        index++;
        //if (index > 3) index = 0;
        //if (index > 0) index = 0;
    }

    [SerializeField]
    private float desiredRotation;

    void Start(){
        index = 0;
        desiredRotation = 0f;
        bf = new BinaryFormatter();
        //File.Delete(Application.persistentDataPath + SaveKey.SKILLDATABASE_KEY);
    }

    void Update(){
        desiredRotation = 90f * index;
        if(transform.eulerAngles.y < desiredRotation){
            r_a(Vector3.up, 90f);
        }
        if(transform.eulerAngles.y > desiredRotation){
            r_a(Vector3.up, -90f);
        }
    }

    public void SavePlayerName(){
        PlayerAttribute pa = attributes[index];
        playerData.Name = pa.getPlayerName();
        playerData.Level = playerData.currentStage = 1;
        playerData.TotalMoney = 100;
        Save<PlayerData>(SaveKey.PLAYERDATA_KEY, playerData);
        Save<List<string>>(SaveKey.SKILLDATABASE_KEY, pa.getPlayerSkillNames());
        Save<InventoryData>(SaveKey.INVENTORY_KEY, id);
        List<PlayerTalentList> ptl = Load<List<PlayerTalentList>>(SaveKey.PLAYERTALENTDATABASE_KEY);
        for(int i = 0; i < ptl.Count; i++){
            if(ptl[i].getName() == playerData.Name){
                Talent t = ptl[i].getTalentByName(playerData.Name)[0];
                Save<Talent>(SaveKey.CURRENTTALENT_KEY, t);
                break;
            }
        }
    }

    private void Save<T>(string path, T obj)
    {
        fs = File.Create(Application.persistentDataPath + path);
        bf.Serialize(fs, obj);
        fs.Close();
    }

    private T Load<T>(string path){
        fs = File.Open(Application.persistentDataPath + path, FileMode.Open);
        T t = (T) bf.Deserialize(fs);
        fs.Close();
        return t;
    }
}
