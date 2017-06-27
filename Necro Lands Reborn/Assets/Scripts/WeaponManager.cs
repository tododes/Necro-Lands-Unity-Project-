using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    [SerializeField]
    private List<Gun> guns = new List<Gun>();

    [SerializeField]
    private Transform gunHolder;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
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
}
