using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopListViewButton : Button {
    private ShopListView shopListView;
    private int amountIncrement;
	new void Start () {
        shopListView = GetComponentInParent<ShopListView>();
        if (name.Contains("- 1"))
            amountIncrement = -1;
        else if (name.Contains("+ 1"))
            amountIncrement = 1;
        onClick.AddListener(AddShopListViewAmount);
    }

    public void AddShopListViewAmount() { shopListView.addAmount(amountIncrement); }
	
	// Update is called once per frame
	void Update () {
		
	}
}
