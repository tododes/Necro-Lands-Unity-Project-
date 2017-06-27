using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBody : TodoBehaviour {

    protected Collider coll;
    protected Rigidbody body;
    // Use this for initialization

    protected virtual void Start(){
        coll = Cp<Collider>();
        body = Cp<Rigidbody>();
    }

    public virtual void OnGetHitReaction(){

    }

}
