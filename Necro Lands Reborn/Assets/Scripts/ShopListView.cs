using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopListView : TodoBehaviour {

    [SerializeField] private Item item;
    [SerializeField] private SureBuyPanel panel;
    [SerializeField] private ItemSpriteDatabase itemSpriteDB;
 
    public Item getItem() { return item; }

    public void Buy(){
        panel.setItem(item);
        panel.Trigger();
    }

    void Start(){
        Cp<Button>().onClick.AddListener(Buy);
        Cp<Image>().sprite = itemSpriteDB.getSpriteByItem(item); 
        //Cp<Image>().sprite = item.sprite;
    }
}
