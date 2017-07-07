using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillShopItem : TodoBehaviour {

    [SerializeField]
    private Skill skill;

    [SerializeField]
    private int price;

    private SkillShopController controller;
    private SkillDatabase skillDB;
    private PlayerData pData;

    void Start(){
        Cp<Button>().onClick.AddListener(OnClick);
        controller = SkillShopController.singleton;
        skillDB = new SkillDatabase();
    }

    public void OnClick(){
        if(controller.getPlayerMoney() >= price){
            string Name = skillDB.getNameOfSkill(skill);
            pData.AddSkillName(Name);
        }
    }

    public Skill containedSkill{
        get { return skill; }
        set { skill = value; }
    }
}
