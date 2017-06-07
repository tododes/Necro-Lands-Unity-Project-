using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour {

    public static InventoryManager singleton;
    [SerializeField] private List<Item> items = new List<Item>();

    [SerializeField]
    private ItemSprite[] itemImages;

    [SerializeField] private KeyCode[] itemKeys;
    [SerializeField] private InventoryData inventoryData;

    void Awake (){
        singleton = this;
        itemImages = GetComponentsInChildren<ItemSprite>();
	}

    void Start(){
        for (int i = 0; i < inventoryData.getCurrentSavedItemsCount(); i++){
            items.Add(inventoryData.getCurrentSavedItemsAt(i));
        }
    }

    public void AddItemToInventory(Item i){
        items.Add(i);
    }

	
	void Update ()
    {
        for (int i = 0; i < items.Count; i++) {
            itemImages[i].setItem(items[i]);
            itemImages[i].SetKey(itemKeys[i]);
        }
	}
}
