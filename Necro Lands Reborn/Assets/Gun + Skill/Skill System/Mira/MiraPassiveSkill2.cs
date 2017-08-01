using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiraPassiveSkill2 : Skill {

    [SerializeField] private MiraBullet bullet;

    public override void InitializeSkill(){
        base.InitializeSkill();
        //Debug.Log(owner.transform.GetChild(0).GetChild(0).name);
        gun = owner.transform.GetChild(0).GetChild(0).GetComponent<Gun>();
        if (!gun.isThisTheBulletToBeInstantiated(bullet.gameObject))
            gun.SetBulletToBeInstantiated(bullet.gameObject);
        bullet.ModifyCombatFury(20);
    }
}
