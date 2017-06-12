using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucyActiveSkill2 : Skill {

    [SerializeField] private GameObject lucyBullet;

    public override void Use(){
        base.Use();
        gun.SetBulletToBeInstantiated(lucyBullet);
    }
}
