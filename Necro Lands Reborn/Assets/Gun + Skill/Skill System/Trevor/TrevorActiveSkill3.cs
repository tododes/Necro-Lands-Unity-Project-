using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrevorActiveSkill3 : Skill {

    [SerializeField] private GameObject meteorSpawner;
    [SerializeField] private GameObject meteors;

    public override void InitializeSkill(){
        meteorSpawner = Instantiate(meteorSpawner) as GameObject;
        meteorSpawner.transform.parent = owner.transform;
    }

    public override void Use(){
        base.Use();
        Instantiate(meteors, meteorSpawner.transform.position, meteorSpawner.transform.rotation);
    }
}
