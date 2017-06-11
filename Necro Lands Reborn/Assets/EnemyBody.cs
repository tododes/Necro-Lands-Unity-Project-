using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBody : CharacterBody {


    private Enemy me;
    private bool inRange;
 
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        me = Cp<Enemy>();
        inRange = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider coll)
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

    void OnTriggerExit(Collider coll)
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

    private IEnumerator AttackPlayer(FPSCharacter fpsCharacter)
    {
        while (inRange)
        {
            yield return new WaitForSeconds(1);
            int damage = (int)(me.GetAttack * 100 / (100 + (fpsCharacter.GetArmor * 2)));
            fpsCharacter.getDamage(damage);
            CharacterBody body = fpsCharacter.GetComponent<CharacterBody>();
            if (body){
                body.OnGetHitReaction();
            }
        }
    }
}
