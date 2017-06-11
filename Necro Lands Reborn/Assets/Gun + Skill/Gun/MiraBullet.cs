using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiraBullet : Bullet {

    public override void OnHitEnemy(Enemy enemy, int damage){
        if(enemy.GetHP <= 0){
            StartCoroutine(ActivateBonusDamage());
        }
    }

    private IEnumerator ActivateBonusDamage(){
        owner.ModifyAttack(20);
        yield return new WaitForSeconds(10);
        owner.ModifyAttack(-20);
    }
}
