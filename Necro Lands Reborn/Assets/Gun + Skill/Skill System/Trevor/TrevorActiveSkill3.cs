using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrevorActiveSkill3 : Skill {

    [SerializeField] private GameObject meteorSpawner;
    [SerializeField] private GameObject meteors;
    private WaitForSeconds meteorInterval = new WaitForSeconds(0.8f);
    private Vector3 meteorPos;

    public override void InitializeSkill(){
        meteorSpawner = Instantiate(meteorSpawner) as GameObject;
        meteorSpawner.transform.parent = owner.transform;
    }

    public override void Use(){
        base.Use();
        meteorPos = meteorSpawner.transform.position;
        StartCoroutine(SpawnMeteor());
    }

    private IEnumerator SpawnMeteor(){
        for(int i = 0; i < 4; i++){
            Instantiate(meteors, meteorPos, meteorSpawner.transform.rotation);
            yield return meteorInterval;
        }
    }
}
