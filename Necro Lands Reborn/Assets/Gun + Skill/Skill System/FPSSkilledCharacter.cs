using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class FPSSkilledCharacter : FPSCharacter
{
    [SerializeField] private float HPRegen, Lifesteal, spellLifesteal, magicAmplification;

    [SerializeField]
    private List<Skill> skills;
    List<KeyCode> keys = new List<KeyCode>();

    [SerializeField]
    private SkillSprite[] sprites;

    [SerializeField]
    private WeaponManager weaponManager;

    [SerializeField]
    private GameObject[] skillHolder;

    [SerializeField]
    private Talent talent;

    //private Dictionary<string, System.Action> playerSkillMapping = new Dictionary<string, System.Action>();
    private BinaryFormatter bf;

    [SerializeField]
    private SkillDatabase skillDB;

    [SerializeField]
    List<string> skillNames = new List<string>();

    void Awake(){
        //skills = GetComponentsInChildren<Skill>();
        bf = new BinaryFormatter();
        FileStream ffs = File.Open(Application.persistentDataPath + SaveKey.SKILLDATABASE_KEY, FileMode.Open);
        skillNames = (List<string>)bf.Deserialize(ffs);
        ffs.Close();

        //Debug.Log("Skillname : " + skillNames.Count);
        for(int i = 0; i < skillNames.Count; i++){
            Skill skill = skillDB.getSkillByName(skillNames[i]);
            Debug.Log(skill.name);
            Skill skillObj = Instantiate<Skill>(skill);
           
            skillObj.gameObject.transform.parent = transform;
            skillObj.gameObject.transform.localPosition = Vector3.zero;
            skills.Add(skillObj);
        }
        for (int i = 0; i < skills.Count; i++){
            keys.Add(KeyCode.Alpha1 + i);
        }
        for (int i = 0; i < skills.Count; i++){
            sprites[i].SetKeyCode(keys[i]);
            sprites[i].SetSkill(skills[i]);
            skills[i].setOwner(this);
        }
        weaponManager = Cp_C<WeaponManager>();
      
    }

    protected new void Start(){
        base.Start();
       
        if (File.Exists(Application.persistentDataPath + SaveKey.CURRENTTALENT_KEY)){
            FileStream fs = File.Open(Application.persistentDataPath + SaveKey.CURRENTTALENT_KEY, FileMode.Open);
            talent = (Talent)bf.Deserialize(fs);
            MaxHP += talent.BonusHP;
            HP += talent.BonusHP;
            Attack += talent.BonusAttack;
            Armor += talent.BonusArmor;
            Speed += talent.BonusMoveSpeed;
            //HPRegen += talent.BonusHPRegen;
            Lifesteal += talent.BonusLifesteal;
            spellLifesteal += talent.BonusSpellLifesteal;
            magicAmplification += talent.trevorModifier.bonusMagicDamage;
        }

        //playerSkillMapping.Add("Gregory", () => {
        //    skillHolder[0].AddComponent<GregoryPassiveSkill>();
        //    skillHolder[1].AddComponent<GregoryActiveSkill1>();
        //    skillHolder[2].AddComponent<GregoryActiveSkill2>();
        //});

        //playerSkillMapping.Add("Trevor", () => {
        //    skillHolder[0].AddComponent<TrevorPassiveSkill>();
        //    skillHolder[1].AddComponent<TrevorActiveSkill1>();
        //    skillHolder[2].AddComponent<TrevorActiveSkill2>();
        //});

        //playerSkillMapping.Add("Mira", () => {
        //    skillHolder[0].AddComponent<MiraSkill>();
        //    skillHolder[1].AddComponent<MiraActiveSkill1>();
        //    //skillHolder[2].AddComponent<GregoryActiveSkill2>();
        //});

        //playerSkillMapping.Add("Lucy", () => {
        //    skillHolder[0].AddComponent<LucySkill>();
        //    skillHolder[1].AddComponent<LucyActiveSkill1>();
        //    skillHolder[2].AddComponent<LucyActiveSkill2>();
        //});

        //playerSkillMapping[Name].Invoke();
       
    }

    public float getSpellLifesteal(){
        return spellLifesteal;
    }

    void Update(){
        
    }
}
