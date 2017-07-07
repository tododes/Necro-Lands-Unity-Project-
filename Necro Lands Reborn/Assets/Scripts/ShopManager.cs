using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ShopManager : MonoBehaviour {

    [SerializeField]
    private PlayerData playerData;
    [SerializeField]
    private InventoryData inventoryData;


    private BinaryFormatter bf;
    private FileStream fs;

    public static ShopManager singleton;

    void Awake() { singleton = this; }

    public void Save<T>(string path, T obj){
        fs = File.Create(Application.persistentDataPath + path);
        bf.Serialize(fs, obj);
        fs.Close();
    }

    public T Load<T>(string path){
        fs = File.Open(Application.persistentDataPath + path, FileMode.Open);
        T obj = (T)bf.Deserialize(fs);
        fs.Close();
        return obj;
    }

    void Start(){
        bf = new BinaryFormatter();
        playerData = Load<PlayerData>(Application.persistentDataPath + SaveKey.PLAYERDATA_KEY);
        inventoryData = Load<InventoryData>(Application.persistentDataPath + SaveKey.INVENTORY_KEY);
    }

    public void BuyItem(Item item){
        inventoryData.AddAllSavedItems(item);
        playerData.TotalMoney -= item.price;
        EndShopScene();
    }

    public void EndShopScene(){
        Save<InventoryData>(Application.persistentDataPath + SaveKey.INVENTORY_KEY, inventoryData);
        Save<PlayerData>(Application.persistentDataPath + SaveKey.PLAYERDATA_KEY, playerData);
    }
}
