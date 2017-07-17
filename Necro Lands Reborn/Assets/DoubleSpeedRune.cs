using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleSpeedRune : Rune {

    public override void RuneInteraction(FPSCharacter character){
        StartCoroutine(Effect(character));
        base.RuneInteraction(character);
    }

    private IEnumerator Effect(FPSCharacter character)
    {
        character.ModifySpeed(character.GetSpeed);
        yield return new WaitForSeconds(DurationOfEffect);
        character.ModifySpeed(character.GetSpeed / -2f);
    }
}
