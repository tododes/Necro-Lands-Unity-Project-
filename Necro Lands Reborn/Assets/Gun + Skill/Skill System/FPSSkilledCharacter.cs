using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FPSSkilledCharacter : FPSCharacter
{
    [SerializeField]
    private Skill[] skills;
    List<KeyCode> keys = new List<KeyCode>();

    [SerializeField]
    private SkillSprite[] sprites;

    [SerializeField]
    private WeaponManager weaponManager;

    void OnEnable(){
        skills = GetComponentsInChildren<Skill>();
        for (int i = 0; i < skills.Length; i++){
            keys.Add(KeyCode.Alpha1 + i);
        }
        for (int i = 0; i < skills.Length; i++){
            sprites[i].SetKeyCode(keys[i]);
            sprites[i].SetSkill(skills[i]);
            skills[i].setOwner(this);
        }
        weaponManager = Cp_C<WeaponManager>();
    }

 

    void Update()
    {

    }
}
