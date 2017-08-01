using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    [SerializeField]
    private List<Gun> guns = new List<Gun>();

    [SerializeField]
    private Transform gunHolder;

    private int currentWeaponSlotIndex;
    private FPSCharacter character;
    private WaitForSeconds oneSec = new WaitForSeconds(1);

    // Use this for initialization
    void Start () {
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<FPSCharacter>();
        currentWeaponSlotIndex = 0;
        StartCoroutine(setGuns());
	}

    private IEnumerator setGuns(){
        while (!character.isDead()){
            Gun[] gs = gunHolder.GetComponentsInChildren<Gun>();
            guns.Clear();
            for(int i = 0; i < gs.Length; i++){
                guns.Add(gs[i]);
            }
            yield return oneSec;
        }
    }
	
	// Update is called once per frame
	void Update () {
        
        for(int i = 0; i < guns.Count; i++){
            if (i == currentWeaponSlotIndex && !guns[i].gameObject.activeInHierarchy)
                guns[i].gameObject.SetActive(true);
            else if (i != currentWeaponSlotIndex && guns[i].gameObject.activeInHierarchy)
                guns[i].gameObject.SetActive(false);
        }
	}

    public void AddGunToList(Gun gun){
        //guns.Add(gun);
        Gun g = Instantiate<Gun>(gun, gunHolder);
        guns.Add(g);
        g.transform.localPosition = Vector3.zero;
        g.gameObject.SetActive(false);
    }

    public Gun getGunAt(int i){
        return guns[i];
    }

    public int getGunCount(){
        return guns.Count;
    }

    public void IncrementSlotIndex(){
        currentWeaponSlotIndex++;
        if (currentWeaponSlotIndex >= guns.Count)
            currentWeaponSlotIndex = 0;
    }

    public Gun getGunAtCurrentSlotIndex() { return getGunAt(currentWeaponSlotIndex); }
}
