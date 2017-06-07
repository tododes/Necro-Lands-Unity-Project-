using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyText : Text {

    private FPSCharacter character;
	// Use this for initialization
	void Start () {
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSCharacter>();
	}
	
	// Update is called once per frame
	void Update () {
        text = "Money : " + character.GetBounty;
	}
}
