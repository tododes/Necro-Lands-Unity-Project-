using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiraActiveSkill1 : Skill {

    [SerializeField] private GameObject miraGun;
    private Vector3 gunPosition;

    public override void Use(){
        base.Use();
    }

    public override void InitializeSkill(){
        gun = owner.GetComponentInChildren<Gun>();
        gunPosition = gun.gameObject.transform.localPosition;
        Destroy(gun.gameObject);
        GameObject g = Instantiate(miraGun) as GameObject;
        g.transform.parent = owner.transform;
        g.transform.localPosition = gunPosition;
    }
}
