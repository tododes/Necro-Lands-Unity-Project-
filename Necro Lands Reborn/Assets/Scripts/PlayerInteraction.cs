using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : TodoBehaviour {
    [SerializeField] private Interactable currentInteractable;

    public void setInteractable(Interactable i){
        currentInteractable = i;
    }

    public bool ScanPlayerAction(KeyCode keyCode){
        if (Input.GetKeyDown(keyCode)){
            return true;
        }
        return false;
    }
}
