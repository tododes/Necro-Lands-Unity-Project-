using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageItemView : TodoBehaviour {

    private Item MyItem;
    private PlayerMenuManager playerMenuManager;
    private Button button;
    [SerializeField] private Image image;
	// Use this for initialization
	void Start () {
        playerMenuManager = PlayerMenuManager.singleton;
        button = Cp<Button>();
        image = Cp_C<Image>();
        button.onClick.AddListener(AddToBattleInventory);
	}

	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetItem(Item i) {
        MyItem = i;
        if(!image)
            image = Cp_C<Image>();
        image.sprite = i.sprite;
    }
    public Item getItem() { return MyItem; }

    public void AddToBattleInventory(){
        playerMenuManager.AddToBattleInventory(MyItem);
    }
}
