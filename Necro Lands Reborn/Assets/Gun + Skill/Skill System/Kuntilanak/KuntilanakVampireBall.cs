using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuntilanakVampireBall : Magic {

    [SerializeField]
    private int status;

    [SerializeField]
    private GameActor target;

    [SerializeField]
    private float vampireHeal;

    public override void TriggerEnterEffect(GameActor target){
        if (!owner.tag.Contains(target.gameObject.tag)){
            status = 1;
            target.getDamage(damage);
            vampireHeal = 0.5f * damage;
        }
        else if(target == owner && status == 1){
            target.Heal(vampireHeal);
            gameObject.SetActive(false);
        }
    }

    void Update(){

        if(status == 1){
            target = owner;
        }
        transform.LookAt(target.transform.position);
        transform.Translate(Vector3.forward * 8f * Time.deltaTime);
    }

    public int getStatus() { return status; }

    public void setTarget(GameActor ga) { target = ga; }
}
