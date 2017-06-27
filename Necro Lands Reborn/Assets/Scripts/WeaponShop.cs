using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShop : Interactable {
    [SerializeField] private Canvas weaponGUI;
    [SerializeField] private Gun[] guns;
    [SerializeField] private WeaponShopItem[] weapons;
 
	// Use this for initialization
	void Start () {
        ThereIsAPlayerVisiting = false;
        for (int i = 0; i < guns.Length; i++){
            if(guns[i].getSprite())
                weapons[i].setSprite(guns[i].getSprite());
        }
        weaponGUI = transform.GetChild(0).gameObject.GetComponent<Canvas>();
        weaponGUI.enabled = false;
       
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
        if (coll.tag.Contains("Player")){
            OnStopReact(coll.GetComponent<FPSCharacter>());
        }
    }

    public override void OnStartReact(FPSCharacter character)
    {
        base.OnStartReact(character);
        visitingCharacter.getPlayerInteraction().setInteractable(this);
        //Debug.Log(shop);
        foreach (WeaponShopItem w in weapons)
            w.visitingCharacter = visitingCharacter;
        ThereIsAPlayerVisiting = true;
    }

    public override void OnStopReact(FPSCharacter character)
    {
        base.OnStopReact(character);
        weaponGUI.enabled = false;
        foreach (WeaponShopItem w in weapons)
            w.visitingCharacter = null;
        ThereIsAPlayerVisiting = false;
    }

    public override void Interact(FPSCharacter character){
        weaponGUI.enabled = true;
    }
}
