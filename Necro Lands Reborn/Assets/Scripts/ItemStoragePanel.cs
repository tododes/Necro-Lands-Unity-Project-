using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStoragePanel : AreYouSurePanel {

    [SerializeField]
    private List<Item> storageItems = new List<Item>();

    [SerializeField] private List<StorageItemView> itemViews = new List<StorageItemView>();
    [SerializeField] private InventoryData inventoryData;

    void Start(){
        for(int i = 0; i < inventoryData.getAllSavedItemsCount(); i++){
            storageItems.Add(inventoryData.getAllSavedItemsAt(i));
        }
        for (int i = 0; i < inventoryData.getAllSavedItemsCount(); i++){
            itemViews[i].SetItem(storageItems[i]);
        }
    }
}
