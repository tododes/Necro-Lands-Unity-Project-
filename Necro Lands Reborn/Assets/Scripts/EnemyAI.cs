using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : TodoBehaviour {

    private Vector3 destination;
    private FPSCharacter target;
    private NavMeshAgent agent;
    private Enemy myself;
    private Animator anim;
	// Use this for initialization
	void Start () {
        destination = new Vector3(0, pos.y, 0);
        agent = Cp<NavMeshAgent>();
        target = FindObjectOfType<FPSCharacter>();
        myself = Cp<Enemy>();
        anim = Cp<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("Health", myself.GetHP);
        if(myself.GetHP > 0){
            destination.x = target.pos.x;
            destination.z = target.pos.z;
            agent.SetDestination(destination);
        }
        else{
            Debug.Log("Is dead");
            Ds(this);
        }
    }
}
