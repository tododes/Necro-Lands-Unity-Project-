using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : MonoBehaviour {

    public Node parent;
    public Node child;
	// Use this for initialization
	void Start () {
        parent = transform.parent.GetComponent<Node>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll2D){
        if(coll2D.transform.position.y < transform.position.y){
            child = coll2D.GetComponent<Node>();
            child.setParent(parent);
            parent.AddChild(child);
            Debug.Log("Parent meet child");
        }
    }
}
