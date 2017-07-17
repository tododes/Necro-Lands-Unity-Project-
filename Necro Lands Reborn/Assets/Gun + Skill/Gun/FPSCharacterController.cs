using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FPSCharacterController : TodoBehaviour {

    private Vector3 desiredRotation;
    private Rigidbody body;
    private FPSCharacter myself;
    private DamageImage damageImage;
    private Gun currentGun;
    [SerializeField] private bool ToggleWeaponSlotChange;

    [SerializeField] private Canvas[] playerCanvases;
    [SerializeField] private CharacterBody myBody;
    [SerializeField] private WeaponManager weaponManager;

    // Use this for initialization
    void Start () {
        desiredRotation = new Vector3(0, 0, 0);
        body = Cp<Rigidbody>();
        myself = Cp<FPSCharacter>();
        myBody = Cp<CharacterBody>();
        currentGun = weaponManager.getGunAt(0);
	}

    void FixedUpdate(){
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * Time.deltaTime * 270f, 0));
        if (Input.GetAxis("Horizontal") == 0f && Input.GetAxis("Vertical") == 0f)
            body.constraints = RigidbodyConstraints.FreezeAll;
        else
            body.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        transform.Translate(Input.GetAxis("Horizontal") * 0.75f, 0, Input.GetAxis("Vertical") * 0.75f);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!myself.isDead()){
            desiredRotation.y = transform.eulerAngles.y;
            transform.eulerAngles = desiredRotation;
        }
        else{
            if (!damageImage)
                damageImage = myself.getDamageImage();
            foreach (Canvas c in playerCanvases)
                c.enabled = false;
            Ds(myBody);
            damageImage.gameObject.SetActive(false);
            enabled = false;
        }
        
        ToggleWeaponSlotChange = Input.GetMouseButton(1);
        if (ToggleWeaponSlotChange){
            if (Input.GetAxis("Mouse ScrollWheel") != 0f){
                weaponManager.IncrementSlotIndex();
                currentGun = weaponManager.getGunAtCurrentSlotIndex();
            }
        }
    }
}
 