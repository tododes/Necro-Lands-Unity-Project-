using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuntilanakSkill2 : Skill {

    [SerializeField]
    private EnemyBody body;

    public override void InitializeSkill(){
        body = owner.gameObject.GetComponent<EnemyBody>();
        if(body)
            Destroy(body);
    }

    protected override void Update(){
        if(!body)
            body = owner.gameObject.AddComponent<KuntilanakBody>();
        base.Update();
    }
}
