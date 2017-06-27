﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActor : TodoBehaviour {

    [SerializeField] protected float MaxHP;
    [SerializeField] protected float HP;
    [SerializeField] protected float Attack;
    [SerializeField] protected float SpAttack;
    [SerializeField] protected float Armor;
    [SerializeField] protected float SpArmor;
    [SerializeField] protected float Speed;
    [SerializeField] protected int Bounty;

    public float GetMaxHP { get { return MaxHP; } protected set { MaxHP = value; } }
    public float GetHP { get { return HP; } protected set { HP = value; } }
    public float GetAttack { get { return Attack; } protected set { Attack = value; } }
    public float GetSpAttack { get { return SpAttack; } protected set { SpAttack = value; } }
    public float GetArmor { get { return Armor; } protected set { Armor = value; } }
    public float GetSpArmor { get { return SpArmor; } protected set { SpArmor = value; } }
    public float GetSpeed { get { return Speed; } protected set { Speed = value; } }
    public int GetBounty { get { return Bounty; } protected set { Bounty = value; } }

    public void SlowSpeed(float percentage){
        Speed -= percentage * Speed;
    }

    public virtual void getDamage(float amount){
        HP -= amount;
    }

    public void ModifyAttack(int amount){
        Attack += amount;
    }

    public void ModifyArmor(int amount){
        Armor += amount;
    }

    public void ModifyAttack(float amount){
        Attack += amount;
    }

    public void ModifyArmor(float amount){
        Armor += amount;
    }

    public bool isDead() { return HP <= 0f; }

    public void Heal(float amount){
        if (HP < MaxHP)
            HP += amount;
        if(HP > MaxHP){
            HP = MaxHP;
        }
    }
}
