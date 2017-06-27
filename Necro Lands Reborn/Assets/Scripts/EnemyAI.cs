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
    private bool DeadProcess;

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
        if(myself.GetHP > 0 && !target.isDead()){
            destination.x = target.pos.x;
            destination.z = target.pos.z;
            agent.SetDestination(destination);
        }
        else{
            if (!DeadProcess){
                StartCoroutine(ProcessDeath());
                DeadProcess = true;
            }
        }
    }

    private IEnumerator ProcessDeath(){
        //AnimatorStateInfo animInfo = anim.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(2);
        Debug.Log("Is dead");
        gameObject.SetActive(false);
    }
}
