using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiraBullet : Bullet {

    [SerializeField]
    private float FuryShotPercentage;

    [SerializeField]
    private int CombatFuryBonus;

    public override void OnHitEnemy(Enemy enemy, int damage){
        StartCoroutine(ActivateDamageFury(FuryShotPercentage));
        if(enemy.GetHP <= 0){
            StartCoroutine(ActivateBonusDamage());
        }
    }

    private IEnumerator ActivateBonusDamage(){
        owner.ModifyAttack(CombatFuryBonus);
        yield return new WaitForSeconds(10);
        owner.ModifyAttack(-CombatFuryBonus);
    }

    private IEnumerator ActivateDamageFury(float percentage){
        float bonusDamage = owner.GetAttack * percentage;
        owner.ModifyAttack(bonusDamage);
        Debug.Log("Add damage");
        yield return new WaitForSeconds(7);
        Debug.Log("Reset");
        owner.ModifyAttack(-bonusDamage);
    }

    public void ModifyCombatFury(int i) { CombatFuryBonus += i; }
    public void ModifyFuryShot(float f) { FuryShotPercentage += f; }
}
