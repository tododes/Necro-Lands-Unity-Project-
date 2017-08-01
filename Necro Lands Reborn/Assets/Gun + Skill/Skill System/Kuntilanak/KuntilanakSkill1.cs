using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuntilanakSkill1 : Skill {

    [SerializeField] private GameActor target;
    [SerializeField] private KuntilanakVampireBall vampireBallPrefab;

    public override void InitializeSkill()
    {
        Use();
    }

    public override void Use(){
        base.Use();
        KuntilanakVampireBall kvb = Instantiate(vampireBallPrefab, transform.position, Quaternion.identity);
        kvb.setOwner(owner);
        kvb.setTarget(target);
    }
}
