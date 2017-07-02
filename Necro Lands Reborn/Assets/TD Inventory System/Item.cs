using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item{

    protected bool Consumable;
    protected int Amount;

    public bool Active;

    [Header("Passive Bonus")]
    public int bonusHP;
    public int bonusAttack;
    public int bonusArmor;
    public int bonusSpAttack;
    public int bonusSpArmor;
    public int bonusSpeed;

    [Header("Active Bonus")]
    public int activeBonusHP;
    public int activeBonusAttack;
    public int activeBonusArmor;
    public int activeBonusSpAttack;
    public int activeBonusSpArmor;
    public int activeBonusSpeed;

    public int price;

    [Header("Passive Modifier Bonus")]
    public Modifier passiveModifier;

    [Header("Active Modifier Bonus")]
    public Modifier activeModifier;

    [Header("Other Bonus")]
    public float damageReturn;
    
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
        character.AddModifier(passiveModifier);
    }

    public virtual void OnEffect(){

    }

    public virtual void OnEffect(FPSCharacter character){
        character.AddModifier(activeModifier);
    }
}

[System.Serializable]
public struct Modifier {
    public float critical;
    public float slow;
    public float armorReduction;
    public float lifeSteal;

    public static Modifier operator +(Modifier mod1, Modifier mod2) {
        mod1.critical += mod2.critical;
        mod1.slow += mod2.slow;
        mod1.armorReduction += mod2.armorReduction;
        mod1.lifeSteal += mod2.lifeSteal;
        return mod1;
    }
}
