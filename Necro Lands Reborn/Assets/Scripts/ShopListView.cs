using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopListView : MonoBehaviour {

    [SerializeField] private Item item;
    [SerializeField] private int amount;

    public Item getItem() { return item; }
    public int getAmount() { return amount; }
    public void addAmount(int a) { amount += a; } 
}
