using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySpawner : TodoBehaviour {

    [SerializeField] private GameModeEnemyDatabase enemyDB;
    [SerializeField] private List<Enemy> enemies;
    [SerializeField] private float multiplier;
    [SerializeField] private float interval;
    [SerializeField] private AreYouSurePanel waveWarningText;
    private float originalInterval;
    //private Action spawnPhaseAction;
    private int phase;

    private WaitForSeconds waveOneTwoTransitionInterval = new WaitForSeconds(10);
    private WaitForSeconds waveTwoThreeTransitionInterval = new WaitForSeconds(13);
    private WaitForSeconds waveWarningDuration = new WaitForSeconds(3);

    void Start () {
        originalInterval = interval;
        enemies = new List<Enemy>(enemyDB.getEnemies());
        multiplier = Mathf.Clamp(multiplier, 1, 100);
        StartCoroutine(WavePhaseOne());
        phase = 1;
        //spawnPhaseAction = () => {
        //    //if (phase == 1){
        //    //    interval -= 0.1f;
        //    //    if (interval <= originalInterval - 2)
        //    //        phase++;
        //    //}
        //    //else if (phase == 2){
        //    //    interval += 0.1f;
        //    //    if (interval >= originalInterval - 2)
        //    //        phase++;
        //    //}
                
        //};
	}

    private IEnumerator WavePhaseOne(){
        
        for(int i = 0; i < 15; i++){
            yield return new WaitForSeconds(interval);
            Spawn();
            //Debug.Log("One");
            interval -= 0.1f;
        }
        yield return waveOneTwoTransitionInterval;
        StartCoroutine(WavePhaseTwo());
    }

    private IEnumerator WavePhaseTwo(){

        interval = 0.1f;
        
        for (int i = 0; i < 20; i++){
            yield return new WaitForSeconds(interval);
            Spawn();
            //Debug.Log("Two");
            interval += 0.1f;
        }
        yield return waveTwoThreeTransitionInterval;
        StartCoroutine(WavePhaseThree());
    }

    private IEnumerator WavePhaseThree(){
        interval = 0.1f;
        for (int i = 0; i < 25; i++){
            yield return new WaitForSeconds(interval);
            Spawn();
            //Debug.Log("Three");
            interval += 0.2f;
        }
    }

    private IEnumerator WaveTextInflate(){
        waveWarningText.Trigger();
        yield return waveWarningDuration;
        waveWarningText.No();
    }

    void Spawn(){
        int r = UnityEngine.Random.Range(0, enemies.Count);
        GameObject go = Instantiate(enemies[r].gameObject, pos, rot) as GameObject;
        
    }

 //   private IEnumerator KeepSpawning(){
 //       Spawn();
 //       while (true){
 //           yield return new WaitForSeconds(interval);
 //           Spawn();
 //       }
 //   }

	//void Update () {
		
	//}
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
