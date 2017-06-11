.using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GregoryPassiveSkill : Skill {

    public override void InitializeSkill(){
        if (!owner)
            Debug.Log("Owner is null");
        owner.gameObject.AddComponent<GregoryBody>();
    }
}
