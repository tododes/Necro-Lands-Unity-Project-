using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocongSkill1 : Skill {

    public override void InitializeSkill(){
        SphereCollider sColl = gameObject.AddComponent<SphereCollider>();
        PocongAura aura = gameObject.AddComponent<PocongAura>();
        aura.setOwner(owner);
        aura.setSlowRate(0.15f);
        sColl.radius = 10f;
        sColl.isTrigger = true;
    }

    
}
