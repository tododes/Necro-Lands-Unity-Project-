using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class FPSSkilledCharacter : FPSCharacter
{
    [SerializeField] private float HPRegen, Lifesteal, spellLifesteal, magicAmplification;

    [SerializeField]
    private Skill[] skills;
    List<KeyCode> keys = new List<KeyCode>();

    [SerializeField]
    private SkillSprite[] sprites;

    [SerializeField]
    private WeaponManager weaponManager;

   
    private BinaryFormatter bf;

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

    protected new void Start(){
        base.Start();
        bf = new BinaryFormatter();
        FileStream fs = File.Open(Application.persistentDataPath + TalentTreeController.TalentDataPath, FileMode.Open);
        Talent talent = (Talent) bf.Deserialize(fs);
        MaxHP += talent.BonusHP;
        HP += talent.BonusHP;
        Attack += talent.BonusAttack;
        Armor += talent.BonusArmor;
        Speed += talent.BonusMoveSpeed;
        HPRegen += talent.BonusHPRegen;
        Lifesteal += talent.BonusLifesteal;
        spellLifesteal += talent.BonusSpellLifesteal;
        magicAmplification += talent.BonusMagicDamage;
    }

    public float getSpellLifesteal(){
        return spellLifesteal;
    }

    void Update(){

    }
}
