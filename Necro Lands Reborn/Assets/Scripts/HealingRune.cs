using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingRune : Rune {

    [SerializeField]
    private float rate;
    [SerializeField]
    private float duration;

    public override void RuneInteraction(FPSCharacter character){
        character.RegenHealth(rate, duration);
        base.RuneInteraction(character);
    }
}
