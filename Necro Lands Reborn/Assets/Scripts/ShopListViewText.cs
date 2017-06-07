using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopListViewText : Text {
    private ShopListView shopListView;
    new void Start(){
        shopListView = GetComponentInParent<ShopListView>();
    }
	// Update is called once per frame
	void Update () {
        text = shopListView.getAmount().ToString();
	}
}
