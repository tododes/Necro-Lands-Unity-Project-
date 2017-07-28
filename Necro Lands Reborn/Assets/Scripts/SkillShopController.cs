using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SkillShopController : TodoBehaviour {

    public static SkillShopController singleton;
    [SerializeField] private PlayerData pData;
    [SerializeField] private List<string> currentPlayerSkillNames = new List<string>();
    private BinaryFormatter bf;

    [SerializeField] private SkillShopItem[] shopItem;

    void Awake(){
        singleton = this;
    }
	// Use this for initialization
	void Start () {
        bf = new BinaryFormatter();
        FileStream fs = File.Open(Application.persistentDataPath + SaveKey.SKILLDATABASE_KEY, FileMode.Open);
        currentPlayerSkillNames = (List<string>) bf.Deserialize(fs);

        fs = File.Open(Application.persistentDataPath + SaveKey.PLAYERDATA_KEY, FileMode.Open);
        pData = (PlayerData) bf.Deserialize(fs);
        Debug.Log(pData.Name);

        fs.Close();
        //shopItem = GetComponentsInChildren<SkillShopItem>();

        //playerSkillDB = new PlayerSkillDatabase(bf);
        //Skill[] skills = playerSkillDB.getSkillsOf(pData.Name);
        //for (int i = 0; i < skills.Length; i++) {
        //    shopItem[i].containedSkill = skills[i];
        //}
	}

    public void SaveData(){
        FileStream fs = File.Create(Application.persistentDataPath + SaveKey.PLAYERDATA_KEY);
        bf.Serialize(fs, pData);
        fs = File.Create(Application.persistentDataPath + SaveKey.SKILLDATABASE_KEY);
        bf.Serialize(fs, currentPlayerSkillNames);
        fs.Close();
    }

    public void AddNewSkillName(string st) { currentPlayerSkillNames.Add(st); }

    public void OnExitScene(){

    }

    public int getPlayerMoney(){
        return pData.TotalMoney;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
