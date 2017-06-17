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
    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Amount = (Consumable) ? Amount : 1;
	}

    public virtual void OnEffect(){

    }

    public virtual void OnEffect(FPSCharacter character){

    }
}
