using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiraGun : Gun {

    [SerializeField] private GameObject leftBullet, rightBullet;
    [SerializeField] private Transform LeftEnd, RightEnd;

    public override void Shoot(){
        base.Shoot();
        leftBullet = Instantiate(bullet, LeftEnd.position, LeftEnd.rotation) as GameObject;
        leftBullet.GetComponent<Bullet>().SetOwner(owner);
        rightBullet = Instantiate(bullet, RightEnd.position, RightEnd.rotation) as GameObject;
        rightBullet.GetComponent<Bullet>().SetOwner(owner);
    }
}
