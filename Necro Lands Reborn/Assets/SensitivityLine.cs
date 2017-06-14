using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensitivityLine : TodoBehaviour {

    private BotAI agent;

    void Start()
    {
        agent = Cp_P<BotAI>();
    }

    void OnTriggerEnter(Collider coll){
        if (coll.tag.Contains("Enemy")){
            Enemy enemy = coll.GetComponent<Enemy>();
            if(!agent.AlreadyInTarget(enemy))
                agent.setCurrentFocusedEnemy(enemy);
            else
                Debug.Log(enemy.name + " Already in the list");
        }
    }


}
