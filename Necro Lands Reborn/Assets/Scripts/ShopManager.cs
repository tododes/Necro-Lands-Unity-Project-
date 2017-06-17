using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ShopManager : MonoBehaviour {

    private Dictionary<Item, int> shoppingCart = new Dictionary<Item, int>();
    public static ShopManager singleton;
    private ShopListView[] shopListViews;

    [SerializeField] private PlayerData playerData;
    [SerializeField] private InventoryData inventoryData;

    private BinaryFormatter bf;
    private FileStream fs;

    void Awake() {
        singleton = this;
    }

    public void AddItemToCart(Item item, int amount){
        shoppingCart.Add(item, amount);
    }
    // Use this for initialization
    void Start () {
        shopListViews = GetComponentsInChildren<ShopListView>();
        bf = new BinaryFormatter();
        playerData = Load<PlayerData>("/PlayerData.data");
        inventoryData = Load<InventoryData>("/InventoryData.data");
	}

    public void GoToPayment(){
        foreach(ShopListView slv in shopListViews){
            if(slv.getAmount() > 0)
                shoppingCart.Add(slv.getItem(), slv.getAmount());
        }
    }

    public void ConfirmPayment(){
        int totalPrice = getTotalBilling();
        if(playerData.TotalMoney >= totalPrice){
            playerData.TotalMoney -= totalPrice;
            Debug.Log("Start");
            foreach (KeyValuePair<Item, int> shoppingItem in shoppingCart){
                Debug.Log(shoppingItem.Key + " " +shoppingItem.Value);
                inventoryData.AddAllSavedItems(shoppingItem.Key);
            }
            Save<PlayerData>("/PlayerData.data", playerData);
            Save<InventoryData>("/InventoryData.data", inventoryData);
        }
    }

    public int getTotalBilling()
    {
        int total = 0;
        foreach(KeyValuePair<Item, int> item in shoppingCart){
            total += item.Key.price * item.Value;
        }
        return total;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

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
}
