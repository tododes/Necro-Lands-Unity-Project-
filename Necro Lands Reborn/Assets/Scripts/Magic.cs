using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : TodoBehaviour {

    [SerializeField] protected float damage;
    [SerializeField] protected float spellLifesteal;
    [SerializeField] protected float slowPercentage;
    [SerializeField] protected GameActor owner;

    public virtual void TriggerEnterEffect(GameActor target){
        //Debug.Log("Target : " + target.name);
        if (!gameObject.tag.Contains(target.gameObject.tag)){
            target.getDamage(damage);
            if (slowPercentage > 0f)
                target.SlowSpeed(slowPercentage, 3);
            if (owner){
                owner.Heal(damage * spellLifesteal);
            }
        }
    }

    protected virtual void OnTriggerEnter(Collider coll){
        GameActor g = coll.GetComponent<GameActor>();
        if (g)
            TriggerEnterEffect(g);
    }

    public GameActor getOwner() { return owner; }
    public void setOwner(GameActor g) { owner = g; }
}
