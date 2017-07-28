using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucyPassiveSkill2 : Skill {

    [SerializeField] private GameObject lucyBullet;

    public override void InitializeSkill(){
        base.InitializeSkill();
        gun.SetBulletToBeInstantiated(lucyBullet);
    }
}
