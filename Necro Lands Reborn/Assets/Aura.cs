using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : TodoBehaviour {

    private SphereCollider coll;

    [SerializeField] private float DamagePerSecond;
    [SerializeField]
    private float SpeedReduction;
    [SerializeField]
    private int ArmorReduction;
    [SerializeField]
    private int AttackReduction;

	void Start () {
        coll = Cp<SphereCollider>();
	}
	
	void Update () {
		
	}

    public virtual void TriggerEnterEffect(GameActor target){
        if (!gameObject.tag.Contains(target.gameObject.tag)){
            target.SlowSpeed(SpeedReduction);
            target.ModifyArmor(-ArmorReduction);
            target.ModifyAttack(-AttackReduction);
        }
        else{

        }
    }

    public virtual void TriggerExitEffect(GameActor target){
        if (!gameObject.tag.Contains(target.gameObject.tag)){
            //target.SlowSpeed(SpeedReduction);
            target.ModifyArmor(ArmorReduction);
            target.ModifyAttack(AttackReduction);
        }
        else{

        }
    }

    public virtual void TriggerStayEffect(GameActor target){
        if (!gameObject.tag.Contains(target.gameObject.tag)){
            target.getDamage(DamagePerSecond * Time.deltaTime);
        }
        else{

        }
    }
}
