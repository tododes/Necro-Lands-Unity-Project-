using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class PlayerMenuManager : MonoBehaviour {

    public static PlayerMenuManager singleton;
    [SerializeField] private List<Item> storage = new List<Item>();
    [SerializeField] private List<Item> inventoryForBattle = new List<Item>();
    [SerializeField] private List<string> playerSkillNames = new List<string>();

    [SerializeField] private InventoryData inventoryData;

    public Sprite DefaultSprite;
    private BinaryFormatter bf;

    void Awake(){
        singleton = this;
    }

    void Start(){
        bf = new BinaryFormatter();
        FileStream fs = File.Open(Application.persistentDataPath + SaveKey.INVENTORY_KEY, FileMode.Open);
        inventoryData = (InventoryData) bf.Deserialize(fs);

        fs = File.Open(Application.persistentDataPath + SaveKey.SKILLDATABASE_KEY, FileMode.Open);
        playerSkillNames = (List<string>)bf.Deserialize(fs);

        fs.Close();
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
        FileStream fs = File.Create(Application.persistentDataPath + SaveKey.INVENTORY_KEY);
        bf.Serialize(fs, inventoryData);
        fs.Close();
    }
}
