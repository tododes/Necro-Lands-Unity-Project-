using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeakSkill1 : Skill {

    [SerializeField]
    private float burnDPS, radius;

    public override void InitializeSkill(){
        Aura myAura = gameObject.AddComponent<Aura>();
        myAura.ModifyDPS(burnDPS);
        gameObject.tag = "Enemy Aura";
        SphereCollider coll = gameObject.AddComponent<SphereCollider>();
        coll.radius = radius;
        coll.isTrigger = true;
    }
}
