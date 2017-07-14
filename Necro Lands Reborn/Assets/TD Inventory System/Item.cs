using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item{
    public string name;
    //public Sprite sprite;

    protected bool Consumable;
    protected int Amount;
    public bool Active;

    [Header("Passive Bonus")]
    public int bonusHP;
    public int bonusMana;
    public int bonusAttack;
    public int bonusArmor;
    public int bonusSpAttack;
    public int bonusSpArmor;
    public int bonusSpeed;
    public int bonusGoldRegen;
    public float bonusHPRegen;
    public float bonusManaRegen;
    public float shootIntervalReduction;

    [Header("Active Bonus")]
    public int activeBonusHP;
    public int activeBonusAttack;
    public int activeBonusArmor;
    public int activeBonusSpAttack;
    public int activeBonusSpArmor;
    public int activeBonusSpeed;

    public int price;
    public int level;

    [Header("Passive Modifier Bonus")]
    public Modifier passiveModifier;

    [Header("Active Modifier Bonus")]
    public Modifier activeModifier;

    [Header("Other Bonus")]
    public float DPSAura;
    public float damageReturn;
    public float spellLifeSteal;
    public float damageAmplification;
    public int bonusEvasion;
    public bool maim;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	void Update ()
    {
        Amount = (Consumable) ? Amount : 1;
	}

    public virtual void OnPassiveEffect(){

    }

    public virtual void OnPassiveEffect(FPSCharacter character) {
        character.ModifyHealth(bonusHP);
        character.ModifyAttack(bonusAttack);
        character.ModifyArmor(bonusArmor);
        character.AddModifier(passiveModifier);
        character.ModifySpeed(bonusSpeed);
    }

    public virtual void OnEffect(){

    }

    public virtual void OnEffect(FPSCharacter character){
        character.AddModifier(activeModifier);
    }

    public override bool Equals(object obj){
        Item item = (Item) obj;
        return name == item.name;
    }
}

[System.Serializable]
public struct Modifier {
    public float critical;
    public float slow;
    public float armorReduction;
    public float lifeSteal;
    public float bashStun;
    public float cleave;
    public bool bleed;


    public static Modifier operator +(Modifier mod1, Modifier mod2) {
        mod1.critical += mod2.critical;
        mod1.slow += mod2.slow;
        mod1.armorReduction += mod2.armorReduction;
        mod1.lifeSteal += mod2.lifeSteal;
        mod1.bashStun += mod2.bashStun;
        mod1.cleave += mod2.cleave;
        return mod1;
    }
}
