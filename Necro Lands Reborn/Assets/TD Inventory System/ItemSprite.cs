using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemSprite : MonoBehaviour {

    [SerializeField]
    private Item item;
    private Image image;

    [SerializeField]
    private KeyCode myKey;

    [SerializeField] private FPSCharacter character;
    [SerializeField] private ItemSpriteDatabase itemSpriteDB;

    void Start(){
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSCharacter>();
        image = GetComponent<Image>();
    }

    public void SetKey(KeyCode k)
    {
        myKey = k;
    }

    void Update()
    {
        if(Input.GetKey(myKey))
        {
            if(item.Active)
                item.OnEffect(character);
        }
    }

    public void GetPassiveEffect(){
        item.OnPassiveEffect(character);
    }

    public void setItem(Item i) {
        item = i;
        image.sprite = itemSpriteDB.getSpriteByItem(i);
    }

    public Item getItem() { return item; }
}
