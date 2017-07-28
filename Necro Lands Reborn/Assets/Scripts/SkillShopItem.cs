using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillShopItem : TodoBehaviour {

    [SerializeField] private Skill skill;
    [SerializeField] private int price;
    [SerializeField] private SkillDatabase skillDB;

    private SkillShopController controller;
    
    //private PlayerData pData;

    void Start(){
        Cp<Button>().onClick.AddListener(BuySkill);
        controller = SkillShopController.singleton;
        //skillDB = new SkillDatabase();
    }

    //public void OnClick(){
    //    if(controller.getPlayerMoney() >= price){
    //        string Name = skillDB.getNameOfSkill(skill);
    //        pData.AddSkillName(Name);
    //    }
    //}

    //public Skill containedSkill{
    //    get { return skill; }
    //    set { skill = value; }
    //}

    private void BuySkill(){
        if (controller.getPlayerMoney() >= price){
            controller.AddNewSkillName(skillDB.getSkillName(skill));
        }
    }
}
