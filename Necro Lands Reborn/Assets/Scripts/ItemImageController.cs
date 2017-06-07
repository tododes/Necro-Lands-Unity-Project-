using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemImageController : TodoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    [SerializeField] private GameObject itemOptionImage;
    private RectTransform itemOptionRect, MyRect;
    private Vector3 itemOptionPosition;
    private ItemOptionButton optionButton;
    private InventoryItemImage MyImage;

    public void OnPointerEnter(PointerEventData eventData){
        if (MyImage.getItem()){
            Ac(itemOptionImage);
            if (!optionButton)
                optionButton = itemOptionImage.GetComponent<ItemOptionButton>();
            optionButton.setItem(MyImage.getItem());
            itemOptionPosition.y = MyRect.position.y;
            itemOptionRect.position = itemOptionPosition;
        }
    }

    public void OnPointerExit(PointerEventData eventData){
        DeAc(itemOptionImage);
    }

    void Start(){
        itemOptionRect = itemOptionImage.GetComponent<RectTransform>();
        itemOptionPosition = new Vector3(itemOptionRect.position.x, 0, itemOptionRect.position.z);
        MyRect = Cp<RectTransform>();
        MyImage = Cp<InventoryItemImage>();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
