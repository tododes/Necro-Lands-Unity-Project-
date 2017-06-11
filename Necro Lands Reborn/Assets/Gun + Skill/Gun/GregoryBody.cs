using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GregoryBody : CharacterBody {

    private FPSCharacter me;
	// Use this for initialization
	protected override void Start () {
        base.Start();
        me = Cp<FPSCharacter>();
	}

    public override void OnGetHitReaction(){
        StartCoroutine(AddReactiveArmor());
    }

    private IEnumerator AddReactiveArmor(){
        me.ModifyArmor(2);
        yield return new WaitForSeconds(8);
        me.ModifyArmor(-2);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
