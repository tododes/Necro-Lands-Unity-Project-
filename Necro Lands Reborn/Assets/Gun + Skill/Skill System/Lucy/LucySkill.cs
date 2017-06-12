using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucySkill : Skill {

    [SerializeField]
    private GameObject charmAuraObject;
    public override void InitializeSkill(){
        GameObject g = Instantiate(charmAuraObject, transform.position, transform.rotation) as GameObject;
        g.transform.parent = owner.transform;
        g.transform.localPosition = Vector3.zero;
    }
}
