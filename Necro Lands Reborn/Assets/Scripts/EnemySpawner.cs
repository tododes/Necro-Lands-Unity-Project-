using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : TodoBehaviour {

    [SerializeField] private List<GameObject> enemies = new List<GameObject>();
    [SerializeField] private float multiplier;
    private List<Parent> parents;

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

//public class EnemyMachine<T> where T : Enemy{

//    private int multiplier;
//    private T instance;
//    public EnemyMachine(int m){
//        multiplier = m;
//    }

//    public void ModifyMultiplier(T i, int addM){
//        instance = i;
//        multiplier += addM;
//    }

//    public T Spawn(){

//        return instance;
//    }
//}

public class Parent
{

}

public class Child : Parent {

}