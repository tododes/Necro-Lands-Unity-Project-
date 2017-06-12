using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrevorActiveSkill1 : Skill {

    private SphereCollider sphereColl;
    [SerializeField] private float damage;
    [SerializeField] private float InActiveRange;
    [SerializeField] private float AreaRange;

    public override void InitializeSkill(){
        Rigidbody r = gameObject.AddComponent<Rigidbody>();
        r.useGravity = false;
        sphereColl = gameObject.AddComponent<SphereCollider>();
        sphereColl.isTrigger = true;
        InActiveRange = sphereColl.radius;
    }

    public override void Use(){
        base.Use();
        sphereColl.enabled = true;
        StartCoroutine(InflateSphere());
    }

    private IEnumerator InflateSphere(){
        while(sphereColl.radius < AreaRange){
            sphereColl.radius += 15f * Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        sphereColl.radius = InActiveRange;
        sphereColl.enabled = false;
    }

    void OnTriggerEnter(Collider coll){
        if (coll.tag.Contains("Enemy")){
            Debug.Log("Scream of pain");
            coll.GetComponent<Enemy>().getDamage(damage);
        }
    }
}
