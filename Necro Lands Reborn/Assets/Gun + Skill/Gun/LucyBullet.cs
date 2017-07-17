using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucyBullet : Bullet {

    [SerializeField] private int poisonDamage;
    private bool onCooldown;

    private WaitForSeconds waitForASecond = new WaitForSeconds(1);

    protected new void Start(){
        base.Start();
        onCooldown = false;
    }

    public override void OnHitEnemy(Enemy enemy, int damage){
        if (!onCooldown){
            StartCoroutine(poisonEnemy(enemy));
            StartCoroutine(poisonCooldown());
        }
        gameObject.SetActive(false);
    }

  

    protected override void Update(){
    
    }

    private IEnumerator poisonEnemy(Enemy enemy){
        for(int i = 0; i< 5; i++){
            yield return waitForASecond;
            enemy.getDamage(poisonDamage);
        }
    }

    private IEnumerator poisonCooldown(){
        onCooldown = true;
        for(int i = 0; i < 15; i++){
            yield return waitForASecond;
        }
        onCooldown = false;
    }
}
