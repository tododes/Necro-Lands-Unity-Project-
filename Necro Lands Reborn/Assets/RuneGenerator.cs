using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneGenerator : TodoBehaviour {

    [SerializeField]
    private Interactable[] runes;

	// Use this for initialization
	void Start () {
        Spawn();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Spawn(){
        StartCoroutine(SpawnRunes());
    }

    private IEnumerator SpawnRunes(){
        while (true){
            yield return new WaitForSeconds(120);
            int r = Random.Range(0, runes.Length);
            Interactable obj = Instantiate(runes[r], transform.position, transform.rotation);
        }
    }
}
