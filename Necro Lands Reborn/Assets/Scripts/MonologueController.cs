using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonologueController : MonoBehaviour {

    public static MonologueController singleton;
    [SerializeField] private Monologue startingMonologue;
    [SerializeField] private List<Monologue> monologues = new List<Monologue>();

    void Awake(){
        singleton = this;
        foreach (Monologue m in monologues){
            m.gameObject.SetActive(false);
        }
        startingMonologue.gameObject.SetActive(true);
    }

    void Start(){
        
    }

    private IEnumerator Next(float delay, Monologue prev, Monologue m){
        prev.gameObject.SetActive(false);
        yield return new WaitForSeconds(delay);
        m.gameObject.SetActive(true);
    }

    public void StartNextMonologue(Monologue prev, Monologue m){
        StartCoroutine(Next(0.5f, prev, m));
    }

 //   void Update () {
	//	//for(int i = 0; i < monologues.Count; i++){
 // //         monologues[i].SetEnable(index == i);
 // //      }
	//}
}
