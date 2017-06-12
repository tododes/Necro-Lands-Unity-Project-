using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucyActiveSkill1 : Skill {

    public override void Use(){
        base.Use();
        StartCoroutine(SwapAttribute());
    }

    private IEnumerator SwapAttribute(){
        float temp = owner.GetAttack - owner.GetArmor;
        owner.ModifyAttack(-temp);
        owner.ModifyArmor(temp);
        yield return new WaitForSeconds(20);
        temp = owner.GetAttack - owner.GetArmor;
        owner.ModifyAttack(-temp);
        owner.ModifyArmor(temp);
    }
}
