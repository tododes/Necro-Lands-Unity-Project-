using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocongAura : Aura {

   private float slowRate;

    public void setSlowRate(float sr) { slowRate = sr; }

    public override void TriggerEnterEffect(GameActor target){
        if (!owner.tag.Contains(target.gameObject.tag)){
            target.ModifyArmor(-10);
            target.SlowSpeed(slowRate);
        }
    }

    public override void TriggerExitEffect(GameActor target){
        if (!owner.tag.Contains(target.gameObject.tag)){
            float per = 1f - slowRate;
            float m = 1f / per;
            m -= 1f;
            target.SlowSpeed(-m);
            target.ModifyArmor(10);
        }
    }
}
