using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrevorActiveSkill2 : Skill {

    [SerializeField] private GameObject sonic;

    public override void Use(){
        base.Use();
        Instantiate(sonic, transform.position, transform.rotation);
    }
}
