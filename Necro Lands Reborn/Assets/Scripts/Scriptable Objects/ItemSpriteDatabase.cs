using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpriteDatabase : ScriptableObject {

    [SerializeField] private List<Item> items;
    [SerializeField] private List<Sprite> sprites;

    public Sprite getSpriteByItem(Item i) { return sprites[items.IndexOf(i)]; }
}
