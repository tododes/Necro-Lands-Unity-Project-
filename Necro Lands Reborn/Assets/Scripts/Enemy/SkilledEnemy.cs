using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkilledEnemy : Enemy {

    [SerializeField] private List<Skill> skills;

    // Use this for initialization
    protected void Awake(){
        skills = new List<Skill>(GetComponentsInChildren<Skill>());
        for(int i = 0; i < skills.Count; i++){
            skills[i].setOwner(this);
        }
    }


	
	// Update is called once per frame
	void Update () {
		
	}
}
