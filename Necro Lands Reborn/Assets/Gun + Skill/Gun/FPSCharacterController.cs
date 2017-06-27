using UnityEngine;
using System.Collections;

public class FPSCharacterController : TodoBehaviour {

    private Vector3 desiredRotation;
    private Rigidbody body;
    private FPSCharacter myself;
    private DamageImage damageImage;

    [SerializeField] private Canvas[] playerCanvases;
    [SerializeField] private CharacterBody myBody;

    // Use this for initialization
    void Start () {
        desiredRotation = new Vector3(0, 0, 0);
        body = Cp<Rigidbody>();
        myself = Cp<FPSCharacter>();
        myBody = Cp<CharacterBody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * Time.deltaTime * 270f, 0));
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
        transform.Translate(Input.GetAxis("Horizontal") * 0.75f, 0, Input.GetAxis("Vertical") * 0.75f);

        if (Input.GetAxis("Horizontal") == 0f && Input.GetAxis("Vertical") == 0f)
            body.constraints = RigidbodyConstraints.FreezeAll;
        else
            body.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        
	}
}
 