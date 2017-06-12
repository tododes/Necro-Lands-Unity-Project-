using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GregoryActiveSkill2 : Skill {

    [SerializeField] private GameObject CylinderPrefab, MyCylinder;
    private Vector3 CylinderPosition;

    public override void InitializeSkill(){
        base.InitializeSkill();
        MyCylinder = Instantiate(CylinderPrefab, transform.position, transform.rotation) as GameObject;
        MyCylinder.SetActive(false);
        CylinderPosition = Vector3.zero;
    }

    public override void Use(){
        base.Use();
        MyCylinder.SetActive(true);
        CylinderPosition.x = owner.transform.position.x;
        CylinderPosition.y = -0.465f;
        CylinderPosition.z = owner.transform.position.z;
        MyCylinder.transform.position = CylinderPosition;
        
    }
}
