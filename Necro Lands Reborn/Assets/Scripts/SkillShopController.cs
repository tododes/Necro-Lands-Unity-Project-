using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SkillShopController : TodoBehaviour {

    public static SkillShopController singleton;
    private PlayerData pData;

    [SerializeField] private PlayerSkillDatabase playerSkillDB;
    [SerializeField] private SkillShopItem[] shopItem;

    void Awake(){
        singleton = this;
    }
	// Use this for initialization
	void Start () {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Open(Application.persistentDataPath + "/PlayerData.data", FileMode.Open);
        pData = (PlayerData) bf.Deserialize(fs);
        shopItem = GetComponentsInChildren<SkillShopItem>();

        playerSkillDB = new PlayerSkillDatabase(bf);
        Skill[] skills = playerSkillDB.getSkillsOf(pData.Name);
        for (int i = 0; i < skills.Length; i++) {
            shopItem[i].containedSkill = skills[i];
        }
	}

    public void OnExitScene(){

    }

    public int getPlayerMoney(){
        return pData.TotalMoney;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
