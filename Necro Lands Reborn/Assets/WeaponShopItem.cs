using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponShopItem : TodoBehaviour {

    [SerializeField] private Gun gun;
    [SerializeField] private int price;
    [SerializeField] private Button MyButton;
    [SerializeField] private Sprite sprite;

    public FPSCharacter visitingCharacter;

	// Use this for initialization
	void Start () {
        MyButton = Cp<Button>();
        MyButton.onClick.AddListener(GiveGunToPlayer);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GiveGunToPlayer(){
        visitingCharacter.getWeaponManager().AddGunToList(gun);
    }

    public void setSprite(Sprite s){
        sprite = s;
    }
}
