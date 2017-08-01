using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiraPassiveSkill1 : Skill {

    [SerializeField] private MiraBullet bullet;

    public override void InitializeSkill(){
        base.InitializeSkill();
        gun = owner.transform.GetChild(0).GetChild(0).GetComponent<Gun>();
        if (!gun.isThisTheBulletToBeInstantiated(bullet.gameObject))
            gun.SetBulletToBeInstantiated(bullet.gameObject);
        bullet.ModifyFuryShot(0.05f);
    }
}
