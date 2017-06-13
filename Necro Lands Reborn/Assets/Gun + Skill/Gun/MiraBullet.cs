using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiraBullet : Bullet {

    public override void OnHitEnemy(Enemy enemy, int damage){
        StartCoroutine(ActivateDamageFury(0.05f));
        if(enemy.GetHP <= 0){
            StartCoroutine(ActivateBonusDamage());
        }
    }

    private IEnumerator ActivateBonusDamage(){
        owner.ModifyAttack(20);
        yield return new WaitForSeconds(10);
        owner.ModifyAttack(-20);
    }

    private IEnumerator ActivateDamageFury(float percentage){
        float bonusDamage = owner.GetAttack * percentage;
        owner.ModifyAttack(bonusDamage);
        Debug.Log("Add damage");
        yield return new WaitForSeconds(7);
        Debug.Log("Reset");
        owner.ModifyAttack(-bonusDamage);
    }
}
