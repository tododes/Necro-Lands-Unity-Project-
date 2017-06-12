using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiraSkill : Skill{

    [SerializeField] private GameObject MiraBullet;

    public override void InitializeSkill(){
        gun.SetBulletToBeInstantiated(MiraBullet);
    }
}
