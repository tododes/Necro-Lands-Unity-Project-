using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAI : TodoBehaviour {

    [SerializeField] private List<Enemy> currentlyFocusedEnemy = new List<Enemy>();
    [SerializeField] private bool IKnowWhereTheEnemyIs;
    [SerializeField] private Gun gun;

    private Vector3 focusedPosition;
    private Vector3 focusedRotatePosition;

	// Use this for initialization
	void Start () {
        focusedPosition = focusedRotatePosition = Vector3.zero;
        gun = Cp_C<Gun>();
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < currentlyFocusedEnemy.Count; i++){
            if (currentlyFocusedEnemy[i].isDead())
                currentlyFocusedEnemy.RemoveAt(i);
        }
        if (IKnowWhereTheEnemyIs){
            focusedRotatePosition = currentlyFocusedEnemy[0].transform.position;
            focusedRotatePosition.y = transform.position.y;
            for (int i = 0; i < currentlyFocusedEnemy.Count; i++)
            {
                if (i > 0)
                {
                    focusedPosition = Vector3.Lerp(focusedPosition, currentlyFocusedEnemy[i].transform.position, 0.5f);
                }
                else
                {
                    focusedPosition = currentlyFocusedEnemy[i].transform.position;
                }
            }
            focusedPosition.y = transform.position.y;
            //focusedPosition.x = currentlyFocusedEnemy.transform.position.x;
            //focusedPosition.y = transform.position.y;
            //focusedPosition.z = currentlyFocusedEnemy.transform.position.z;
            Vector3 distance = focusedPosition - transform.position;
            Vector3 distanceToRotateTarget = focusedRotatePosition - transform.position;
            Quaternion lookEnemy = Quaternion.LookRotation(distanceToRotateTarget);
            Quaternion curr = transform.localRotation;
            transform.localRotation = Quaternion.Slerp(curr, lookEnemy, Time.deltaTime);
            transform.position -= distance * 0.3f * Time.deltaTime;
            gun.Shoot();
        }
    }

    public bool AlreadyInTarget(Enemy e) {
        for (int i = 0; i < currentlyFocusedEnemy.Count; i++){
            if(currentlyFocusedEnemy[i].Equals(e))
                return true;
        }
        return currentlyFocusedEnemy.Contains(e);
    }

    public void setCurrentFocusedEnemy(Enemy e) {
        if(currentlyFocusedEnemy.Count < 3)
            currentlyFocusedEnemy.Add(e);
        IKnowWhereTheEnemyIs = true;
    }
    //public Enemy getCurrentFocusedEnemy() { return currentlyFocusedEnemy; }
}
