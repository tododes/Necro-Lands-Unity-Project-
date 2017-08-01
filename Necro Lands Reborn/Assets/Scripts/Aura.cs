using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aura : Magic {

    private SphereCollider coll;

    [SerializeField]
    private float SpeedReduction;
    [SerializeField]
    private int ArmorReduction;
    [SerializeField]
    private int AttackReduction;

    public void ModifyDPS(float dps) { damage += dps; }

	void Start () {
        coll = Cp<SphereCollider>();
	}
	
	void Update () {
	
	}

    public override void TriggerEnterEffect(GameActor target){
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
            float per = 1f - SpeedReduction;
            float m = 1f / per;
            m -= 1f;
            target.SlowSpeed(-m);
            target.ModifyArmor(ArmorReduction);
            target.ModifyAttack(AttackReduction);
        }
        else{

        }
    }

    public virtual void TriggerStayEffect(GameActor target){
        if (!gameObject.tag.Contains(target.gameObject.tag)){
            target.getDamage(damage * Time.deltaTime);
        }
        else{

        }
    }

    //protected override void OnTriggerEnter(Collider coll) {
    //    GameActor g = coll.GetComponent<GameActor>();
    //    if(g)
    //        TriggerEnterEffect(g);
    //}

    protected void OnTriggerStay(Collider coll){
        GameActor g = coll.GetComponent<GameActor>();
        if (g)
            TriggerStayEffect(g);
    }

    protected void OnTriggerExit(Collider coll){
        GameActor g = coll.GetComponent<GameActor>();
        if (g)
            TriggerExitEffect(g);
    }
}
