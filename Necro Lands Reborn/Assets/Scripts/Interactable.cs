using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    protected FPSCharacter visitingCharacter;
    protected bool ThereIsAPlayerVisiting;
    [SerializeField] protected KeyCode key;

    protected virtual void OnTriggerEnter(Collider coll)
    {
  
    }

    protected void OnTriggerStay(Collider coll){
        if (coll.tag.Contains("Player")){
            FPSCharacter character = coll.GetComponent<FPSCharacter>();
            bool b = visitingCharacter.getPlayerInteraction().ScanPlayerAction(key);
            if (b){
                Interact(character);
            }
        }
    }

    protected virtual void OnTriggerExit(Collider coll){
        if (coll.tag.Contains("Player")){
            FPSCharacter character = coll.GetComponent<FPSCharacter>();
            OnStopReact(character);
        }
    }

    public virtual void Interact(FPSCharacter character){

    }

    public virtual void OnStartReact(FPSCharacter character){
        visitingCharacter = character;
    }

    public virtual void OnStopReact(FPSCharacter character){
        character.getPlayerInteraction().setInteractable(null);
        visitingCharacter = null;
    }
}
