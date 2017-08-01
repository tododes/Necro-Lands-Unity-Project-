using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuntilanakBody : EnemyBody {

    [SerializeField]
    private float lifeSteal = 0.2f;

    protected override void EnemyBodyModifier(Enemy enemy, float damage){
        me.Heal(lifeSteal * damage);
    }
}
