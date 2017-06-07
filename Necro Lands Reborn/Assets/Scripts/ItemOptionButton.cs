using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemOptionButton : Button {

    [SerializeField] private Item item;
    private PlayerMenuManager playerMenuManager;

    public Item getItem() { return item; }
    public void setItem(Item i) { item = i; }
	// Use this for initialization
	new void Start () {
        playerMenuManager = PlayerMenuManager.singleton;
        this.onClick.AddListener(UnEquip);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UnEquip(){
        playerMenuManager.RemoveFromBattleInventory(item);
    }
}
