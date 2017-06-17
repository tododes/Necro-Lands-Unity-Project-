using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : TodoBehaviour {

    [SerializeField] private List<GameObject> enemies = new List<GameObject>();
    [SerializeField] private float multiplier;

	void Start () {
        multiplier = Mathf.Clamp(multiplier, 1, 100);
        StartCoroutine(KeepSpawning());
	}

    void Spawn(){
        int r = Random.Range(0, enemies.Count);
        GameObject go = Instantiate(enemies[r], pos, rot) as GameObject;
    }

    private IEnumerator KeepSpawning(){
        Spawn();
        while (true){
            yield return new WaitForSeconds(5);
            Spawn();
        }
    }

	void Update () {
		
	}
}
