using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryData : ScriptableObject {
   [SerializeField] private List<Item> currentSavedItems = new List<Item>();
   [SerializeField] private List<Item> allSavedItems = new List<Item>();
  
    public int getCurrentSavedItemsCount() { return currentSavedItems.Count; }
    public int getAllSavedItemsCount() { return allSavedItems.Count; }

    public Item getCurrentSavedItemsAt(int slot) { return currentSavedItems[slot]; }
    public Item getAllSavedItemsAt(int slot) { return allSavedItems[slot]; }

    public void AddCurrentSavedItems(Item item) { currentSavedItems.Add(item); }
    public void AddAllSavedItems(Item item) { allSavedItems.Add(item); }

    public void ResetCurrentItems(){
        currentSavedItems.Clear();
    }

    public void ClearStorage() { allSavedItems.Clear(); }
    public void ClearInventory() { currentSavedItems.Clear(); }
}
