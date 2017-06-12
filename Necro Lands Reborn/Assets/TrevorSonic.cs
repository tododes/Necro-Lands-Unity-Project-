using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrevorSonic : MonoBehaviour {

    [SerializeField]
    private float damage;

    [SerializeField]
    private float lifeTime;

    void OnTriggerEnter(Collider coll){
        if (coll.tag.Contains("Enemy")){
            coll.GetComponent<Enemy>().getDamage(damage);
            Debug.Log("Trevor sonic");
        }
    }

    void Update(){
        transform.Translate(Vector3.forward * 50f * Time.deltaTime);
        lifeTime -= Time.deltaTime;
        gameObject.SetActive(lifeTime > 0f);
    }
}
