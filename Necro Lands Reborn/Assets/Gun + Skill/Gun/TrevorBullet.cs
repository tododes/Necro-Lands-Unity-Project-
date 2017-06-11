using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrevorBullet : Bullet {

    [SerializeField]
    private int criticalChance;

    public override void OnHitEnemy(Enemy enemy, int damage)
    {
        int R = Random.Range(0, 100);
        if (R < criticalChance)
            enemy.getDamage(damage);
    }
}
