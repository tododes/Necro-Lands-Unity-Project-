using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBody : TodoBehaviour {

    private Enemy me;
    private bool inRange;
    private Collider collider;
    private Rigidbody body;
    // Use this for initialization
    void Start () {
        me = Cp<Enemy>();
        inRange = false;
        collider = Cp<Collider>();
        body = Cp<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider coll){
        if (coll.tag.Contains("Attack Point")){
            //Debug.Log("Attack");
            inRange = true;
            FPSCharacter fpsCharacter = coll.GetComponentInParent<FPSCharacter>();
            StartCoroutine(AttackPlayer(fpsCharacter));
        }
    }

    void OnTriggerExit(Collider coll){
        if (coll.tag.Contains("Attack Point")){
            inRange = false;
        }
        if (coll.name.Contains("Bullet")){
            Bullet bullet = coll.GetComponent<Bullet>();
            int damage = (int)(bullet.GetDamage() * 100 / (100 + (me.GetArmor)));
            me.getDamage(damage);
            if (me.GetHP <= 0)
            {
                bullet.owner.GainReward(me.getReward());
                collider.enabled = false;
                Destroy(body);
                Ds(this);
            }
        }
    }

    private IEnumerator AttackPlayer(FPSCharacter fpsCharacter){
        while (inRange){
            yield return new WaitForSeconds(1);
            int damage = (int)(me.GetAttack * 100 / (100 + (fpsCharacter.GetArmor * 2)));
            fpsCharacter.getDamage(damage);
        }
    }
}
