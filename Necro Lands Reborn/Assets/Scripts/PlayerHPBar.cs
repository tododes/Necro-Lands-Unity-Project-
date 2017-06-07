using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPBar : HPBar {

    [SerializeField] private FPSCharacter character;
    // Use this for initialization
    protected override void Start() {
        base.Start();
        character = FindObjectOfType<FPSCharacter>();
    }

    // Update is called once per frame
    protected override void Update() {
        desiredSize.x = character.GetHP / character.GetMaxHP * 300;
        base.Update();
    }
}
