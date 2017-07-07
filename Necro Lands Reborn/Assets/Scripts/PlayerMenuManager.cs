using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PlayerMenuManager : MonoBehaviour {

    public static PlayerMenuManager singleton;
    [SerializeField] private List<Item> storage = new List<Item>();
    [SerializeField] private List<Item> inventoryForBattle = new List<Item>();

    [SerializeField] private InventoryData inventoryData;

    public Sprite DefaultSprite;

    void Awake(){
        singleton = this;
    }

    void Start(){
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Open(Application.persistentDataPath + SaveKey.INVENTORY_KEY, FileMode.Open);
        inventoryData = (InventoryData) bf.Deserialize(fs);

        for (int i = 0; i < inventoryData.getAllSavedItemsCount(); i++){
            storage.Add(inventoryData.getAllSavedItemsAt(i));
        }
    }

    public void AddToBattleInventory(Item item){
        if(!inventoryForBattle.Contains(item))
            inventoryForBattle.Add(item);
    }

    public void RemoveFromBattleInventory(Item item){
        if (inventoryForBattle.Contains(item))
            inventoryForBattle.Remove(item);
    }

    public Item getInventoryItemAt(int index) {
        if(index >= 0 && index <= inventoryForBattle.Count - 1)
            return inventoryForBattle[index];
        return null;
    }

    public int getInventoryCount() { return inventoryForBattle.Count; }

    public void SaveBattleInventoryToInventotyData(){
        inventoryData.ResetCurrentItems();
        for(int i = 0; i < inventoryForBattle.Count; i++){
            inventoryData.AddCurrentSavedItems(inventoryForBattle[i]);
        }
    }
}
