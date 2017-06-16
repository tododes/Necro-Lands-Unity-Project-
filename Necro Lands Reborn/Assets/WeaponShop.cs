using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShop : Interactable {
    private WeaponShopItem[] shopItem;
    [SerializeField] private GameObject weaponGUI;
 
	// Use this for initialization
	void Start () {
        ThereIsAPlayerVisiting = false;
        weaponGUI = transform.GetChild(0).gameObject;
        weaponGUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void OnTriggerEnter(Collider coll)
    {
        if (coll.tag.Contains("Player"))
        {
            OnStartReact(coll.GetComponent<FPSCharacter>());
        }
    }

    protected override void OnTriggerExit(Collider coll)
    {
        if (coll.tag.Contains("Player"))
        {
            OnStopReact(coll.GetComponent<FPSCharacter>());
        }
    }

    public override void OnStartReact(FPSCharacter character)
    {
        base.OnStartReact(character);
        visitingCharacter.getPlayerInteraction().setInteractable(this);
        foreach (WeaponShopItem w in shopItem)
            w.visitingCharacter = visitingCharacter;
        ThereIsAPlayerVisiting = true;
    }

    public override void OnStopReact(FPSCharacter character)
    {
        base.OnStopReact(character);
        foreach (WeaponShopItem w in shopItem)
            w.visitingCharacter = null;
        ThereIsAPlayerVisiting = false;
    }

    public override void Interact(FPSCharacter character){
        weaponGUI.SetActive(true);
    }
}
