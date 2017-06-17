using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ItemStoragePanel : AreYouSurePanel {

    [SerializeField]
    private List<Item> storageItems = new List<Item>();

    [SerializeField] private List<StorageItemView> itemViews = new List<StorageItemView>();
    [SerializeField] private InventoryData inventoryData;

    private BinaryFormatter bf;
    private FileStream fs;

    new void Start(){
        base.Start();
        bf = new BinaryFormatter();
        inventoryData = Load<InventoryData>("/InventoryData.data");
        for(int i = 0; i < inventoryData.getAllSavedItemsCount(); i++){
            storageItems.Add(inventoryData.getAllSavedItemsAt(i));
        }
        for (int i = 0; i < inventoryData.getAllSavedItemsCount(); i++){
            itemViews[i].SetItem(storageItems[i]);
        }
    }

    public T Load<T>(string path)
    {
        fs = File.Open(Application.persistentDataPath + path, FileMode.Open);
        T obj = (T)bf.Deserialize(fs);
        fs.Close();
        return obj;
    }
}
