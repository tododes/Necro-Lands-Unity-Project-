using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiraActiveSkill3 : Skill {

    [SerializeField] private MiraGun miraGunPrefab;
    [SerializeField] private Transform gunHolder;
    private bool GunChanged;

    public override void InitializeSkill(){
        base.InitializeSkill();
        gunHolder = owner.transform.GetChild(0);
        GunChanged = false;
        gun = gunHolder.GetChild(0).GetComponent<Gun>();
    }

    protected override void Update(){
        if (!GunChanged){
            GunChanged = true;
            MiraGun mg = Instantiate(miraGunPrefab);
            mg.transform.parent = gunHolder;
            mg.transform.localPosition = Vector3.zero;
            mg.owner = (FPSSkilledCharacter)owner;
            Debug.Log("xxx");
            if(!gun)
                Debug.Log("Gun null");
            else
                Debug.Log(gun.name);
            Destroy(gun.gameObject);
            gun = mg;
        }
        base.Update();
    }
}
