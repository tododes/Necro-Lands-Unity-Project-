using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GregoryPassiveSkill : Skill {

    public override void InitializeSkill(){
        if (!owner)
            Debug.Log("Owner is null");
        CharacterBody cb = owner.gameObject.GetComponent<CharacterBody>();
        Destroy(cb);
        owner.gameObject.AddComponent<GregoryBody>();
    }
}
