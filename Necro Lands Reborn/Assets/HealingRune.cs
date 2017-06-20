using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingRune : Interactable {

    [SerializeField] private float rate;
    [SerializeField] private float duration;

    public override void OnStartReact(FPSCharacter character){
        base.OnStartReact(character);

    }

    public override void Interact(FPSCharacter character){
        base.Interact(character);
        if (Input.GetKeyDown(KeyCode.E)){
            character.RegenHealth(rate, duration);
            gameObject.SetActive(false);
        }
    }

    public override void OnStopReact(FPSCharacter character){
        base.OnStopReact(character);
    }

    void Update(){
        transform.Rotate(0, 360f * Time.deltaTime, 0);
    }
}
