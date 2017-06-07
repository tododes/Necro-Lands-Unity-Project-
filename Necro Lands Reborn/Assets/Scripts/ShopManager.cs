using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour {

    private Dictionary<Item, int> shoppingCart = new Dictionary<Item, int>();
    public static ShopManager singleton;
    private ShopListView[] shopListViews;

    [SerializeField] private PlayerData playerData;
    [SerializeField] private InventoryData inventoryData;

    void Awake() {
        singleton = this;
    }

    public void AddItemToCart(Item item, int amount){
        shoppingCart.Add(item, amount);
    }
    // Use this for initialization
    void Start () {
        shopListViews = GetComponentsInChildren<ShopListView>();
        //inventoryData.ClearStorage();
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
            foreach (KeyValuePair<Item, int> shoppingItem in shoppingCart){
                inventoryData.AddAllSavedItems(shoppingItem.Key);
            }
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
}
