using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GregoryCylinder : Magic {

    private Vector3 rotationRate;
    private Vector3 originPosition;

    void Start(){
        rotationRate = new Vector3(0, -720, 0);
        originPosition = transform.parent.transform.position;
        StartCoroutine(Activation());
    }

    void OnTriggerStay(Collider coll){
        if (coll.tag.Contains("Enemy")) { 
            float dmg = damage * Time.deltaTime;
            coll.GetComponent<Enemy>().getDamage(damage * Time.deltaTime);
            owner.Heal(dmg * spellLifesteal);
        }
    }

    void Update(){
        r_a(rotationRate, 1);
        transform.localPosition = Vector3.zero;
    }

    private IEnumerator Activation(){
        float t = 0f;
        while (t < 1f){
            transform.parent.transform.Translate(Vector3.forward * 10f * Time.deltaTime);
            yield return new WaitForSeconds(Time.deltaTime);
            t += Time.deltaTime;
        }
        yield return new WaitForSeconds(7);
        transform.parent.transform.position = originPosition;
        transform.parent.gameObject.SetActive(false);
    }
}
