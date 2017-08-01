using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Magic {

	void Update () {
        transform.Translate(Vector3.down * 22f * Time.deltaTime);
	}


    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag.Contains("Enemy")){
            coll.GetComponent<Enemy>().getDamage(damage);
            owner.Heal(damage * spellLifesteal);
        }
    }
}
