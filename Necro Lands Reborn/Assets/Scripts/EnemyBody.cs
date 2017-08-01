using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBody : CharacterBody {


    protected Enemy me;
    [SerializeField]
    protected bool inRange;
 
    // Use this for initialization
    protected override void Start(){
        base.Start();
        me = Cp<Enemy>();
        inRange = false;
    }

    // Update is called once per frame
    protected void Update(){

    }

    protected void OnTriggerEnter(Collider coll)
    {
        if (coll.tag.Contains("Attack Point"))
        {
            //Debug.Log("Attack");
            inRange = true;
            FPSCharacter fpsCharacter = coll.GetComponentInParent<FPSCharacter>();
            StartCoroutine(AttackPlayer(fpsCharacter));
        }
        else if (coll.tag.Contains("Aura"))
        {
            Aura aura = coll.GetComponent<Aura>();
            aura.TriggerEnterEffect(me);
        }
    }

    protected void OnTriggerExit(Collider coll)
    {
        if (coll.tag.Contains("Attack Point"))
        {
            inRange = false;
        }
        if (coll.name.Contains("Bullet"))
        {
            Bullet bullet = coll.GetComponent<Bullet>();
            int damage = (int)(bullet.GetDamage() * 100 / (100 + (me.GetArmor)));
            me.getDamage(damage);
            bullet.OnHitEnemy(me, damage);
            OnGetHitReaction();
            if (me.GetHP <= 0)
            {
                bullet.owner.killEnemy();
                bullet.owner.GainReward(me.getReward());
                coll.enabled = false;
                Destroy(body);
                Ds(this);
            }
        }
        else if (coll.tag.Contains("Aura"))
        {
            Aura aura = coll.GetComponent<Aura>();
            aura.TriggerExitEffect(me);
        }

    }

    protected IEnumerator AttackPlayer(FPSCharacter fpsCharacter)
    {
        while (inRange && !fpsCharacter.isDead())
        {
            yield return new WaitForSeconds(1);
            int damage = (int)(me.GetAttack * 100 / (100 + (fpsCharacter.GetArmor * 2)));
            if (damage < 1) damage = 1;
            fpsCharacter.getDamage(damage);
            EnemyBodyModifier(me, damage);
            CharacterBody body = fpsCharacter.GetComponent<CharacterBody>();
            if (body){
                body.OnGetHitReaction();
            }
        }
        
    }

    protected virtual void EnemyBodyModifier(Enemy enemy, float damage){

    }
}
