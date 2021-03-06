﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemImage : Image {

    private Item item;
    private int index;
    private PlayerMenuManager playerMenuManager;
    private Sprite defaultSprite;
    [SerializeField] private ItemSpriteDatabase itemSpriteDB;

    new void Start(){
        base.Start();
        char i = name[name.Length - 1];
        index = (int)i - '0';
        playerMenuManager = PlayerMenuManager.singleton;
        item = null;
        defaultSprite = playerMenuManager.DefaultSprite;
    }

    public void setItem(Item i){
        item = i;
    }

    public Item getItem(){
        return item;
    }

    void Update(){
        if(index < playerMenuManager.getInventoryCount()){
            item = playerMenuManager.getInventoryItemAt(index);
            sprite = itemSpriteDB.getSpriteByItem(item);
        }
        else{
            item = null;
            sprite = defaultSprite;
        }
    
    }
}
