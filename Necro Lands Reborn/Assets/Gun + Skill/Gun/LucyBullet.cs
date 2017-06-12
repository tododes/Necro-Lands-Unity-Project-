using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucyBullet : Bullet {

    [SerializeField] private bool Bouncing;
    [SerializeField] private Enemy next;

    private List<Enemy> nearestEnemies = new List<Enemy>();

    protected new void Start(){

    }

    public override void OnHitEnemy(Enemy enemy, int damage){
        Debug.Log("Lucy bullet bounce");
        next = findNearestEnemyFrom(enemy);
        if (!next.Equals(enemy))
            Bouncing = true;
        else
            gameObject.SetActive(false);
    }

    private Enemy findNearestEnemyFrom(Enemy origin){
        float nearestDistance = 0f;
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        if(enemies.Length == 1 && enemies[0].Equals(origin) && !enemies[0].isDead()){
            return origin;
        }
        else if (enemies.Length == 1 && enemies[0].Equals(origin) && enemies[0].isDead()){
            gameObject.SetActive(false);
            return null;
        }
        else
        {
            List<Enemy> targetList = new List<Enemy>(enemies);
            Enemy chosenEnemy = null;
            for (int i = 0; i < targetList.Count; i++) {
                if (targetList[i].Equals(origin) || targetList[i].isDead())
                    targetList.RemoveAt(i);
            }
            for (int i = 0; i < targetList.Count; i++){
                float d = Vector3.Distance(targetList[i].transform.position, origin.transform.position);
                if (nearestDistance <= 0f || d < nearestDistance)
                {
                    chosenEnemy = targetList[i];
                    nearestDistance = d;
                }
            }
            return chosenEnemy;
        }
       
    }

    protected override void Update(){
        if (!Bouncing){
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        else{
            transform.LookAt(next.transform.position);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
