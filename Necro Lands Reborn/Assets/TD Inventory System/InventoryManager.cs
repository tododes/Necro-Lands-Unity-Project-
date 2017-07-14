using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class InventoryManager : MonoBehaviour {

    public static InventoryManager singleton;
    [SerializeField] private List<Item> items = new List<Item>();

    [SerializeField]
    private ItemSprite[] itemImages;

    [SerializeField] private KeyCode[] itemKeys;
    [SerializeField] private InventoryData inventoryData;

    private BinaryFormatter bf;
    private FileStream fs;

    void Awake (){
        singleton = this;
        itemImages = GetComponentsInChildren<ItemSprite>();
	}

    void Start(){
        bf = new BinaryFormatter();
        fs = File.Open(Application.persistentDataPath + SaveKey.INVENTORY_KEY, FileMode.Open);
        inventoryData = (InventoryData)bf.Deserialize(fs);
        for (int i = 0; i < inventoryData.getCurrentSavedItemsCount(); i++){
            items.Add(inventoryData.getCurrentSavedItemsAt(i));
        }
        for (int i = 0; i < items.Count; i++){
            itemImages[i].setItem(items[i]);
            itemImages[i].SetKey(itemKeys[i]);
            itemImages[i].GetPassiveEffect();
        }
    }

    public void AddItemToInventory(Item i){
        items.Add(i);
    }

	
	void Update ()
    {
 
	}
}
