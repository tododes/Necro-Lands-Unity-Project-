using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPBar : HPBar {

    private Enemy enemy;
	// Use this for initialization
	void Start () {
        enemy = transform.parent.parent.GetComponent<Enemy>();
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
        desiredSize.x = enemy.GetHP / enemy.GetMaxHP * 300;
        base.Update();
	}
}
