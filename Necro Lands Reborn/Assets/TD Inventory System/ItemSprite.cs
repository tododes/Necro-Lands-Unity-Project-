using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemSprite : MonoBehaviour {

    [SerializeField]
    private Item item;
    private Image image;

    [SerializeField]
    private KeyCode myKey;
    private FPSCharacter character;

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

    public void UseItem()
    {
        if (item.Active)
            item.OnEffect();
    }

    public void setItem(Item i) {
        item = i;
    }

    public Item getItem() { return item; }

	//// Use this for initialization
	//void Start () {
	
	//}
	
	//// Update is called once per frame
	//void Update () {
	
	//}
}
