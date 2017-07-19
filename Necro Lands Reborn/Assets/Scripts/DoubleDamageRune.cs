using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDamageRune : Rune {

    public override void RuneInteraction(FPSCharacter character){
        StartCoroutine(Effect(character));
        base.RuneInteraction(character);
    }

    private IEnumerator Effect(FPSCharacter character)
    {
        character.ModifyAttack(character.GetAttack);
        yield return new WaitForSeconds(DurationOfEffect);
        character.ModifyAttack(character.GetAttack / -2f);
    }
}
