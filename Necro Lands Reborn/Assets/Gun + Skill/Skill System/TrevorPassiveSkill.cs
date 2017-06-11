using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrevorPassiveSkill : Skill {

    [SerializeField] private Gun gun;
    [SerializeField] private GameObject trevorBullet;

    public override void InitializeSkill(){
        gun.SetBulletToBeInstantiated(trevorBullet);
    }
}
