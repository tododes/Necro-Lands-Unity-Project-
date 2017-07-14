using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SureBuyPanel : AreYouSurePanel {

    [SerializeField] private Item item;

    private ShopManager manager;

    new void Start(){
        base.Start();
        manager = ShopManager.singleton;
    }

    public void setItem(Item i) { item = i; }

    public override void Yes(string name){
        manager.BuyItem(item);
        No();
    }
}
