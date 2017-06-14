using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : GameActor {

    public int GoldGain { get; protected set; }
    public int ID;
   
    [SerializeField] private Reward reward;

    void Start(){
        HP = MaxHP = 100;
        GoldGain = 50;
    }

    public Reward getReward() { return reward; }

    void Update(){
        
    }
    //void OnTriggerStay(Collider coll)
    //{
    //    if (coll.name == "FlamethrowerAOE")
    //        HP -= 10f * Time.deltaTime;
    //    if (coll.name == "WaterSprayAOE")
    //        HP -= 10f * Time.deltaTime;
    //}

    public override bool Equals(object other)
    {
        Enemy otherEnemy = (Enemy)other;
        return (otherEnemy.ID == ID) && (gameObject.name == otherEnemy.gameObject.name);
    }
}
