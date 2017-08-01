using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucyBullet : Bullet {

    [SerializeField] private int poisonDamage;
    private bool onCooldown;

    private WaitForSeconds waitForASecond = new WaitForSeconds(1);
    private MeshRenderer myRenderer;
    private Light light;
    private bool NotActiveAnymore;

    protected new void Start(){
        base.Start();
        onCooldown = false;
        myRenderer = GetComponent<MeshRenderer>();
        light = GetComponent<Light>();
    }

    public override void OnHitEnemy(Enemy enemy, int damage){
        myRenderer.enabled = light.enabled = false;
        NotActiveAnymore = true;
        if (!onCooldown){
            StartCoroutine(poisonEnemy(enemy));
            StartCoroutine(poisonCooldown());
        }
        
    }

  

    protected override void Update(){
        if(!NotActiveAnymore)
            base.Update();
    }

    private IEnumerator poisonEnemy(Enemy enemy){
        for (int i = 0; i< 5; i++){
            yield return new WaitForSeconds(1);
            enemy.getDamage(poisonDamage);
        }
        gameObject.SetActive(false);
    }

    private IEnumerator poisonCooldown(){
        onCooldown = true;
        for(int i = 0; i < 15; i++){
            yield return waitForASecond;
        }
        onCooldown = false;
    }
}
