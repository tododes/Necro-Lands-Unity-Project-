using UnityEngine;
using System.Collections;

public class FPSCharacterController : MonoBehaviour {

    private Vector3 desiredRotation;
	// Use this for initialization
	void Start () {
        desiredRotation = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * Time.deltaTime * 270f, 0));
        desiredRotation.y = transform.eulerAngles.y;
        transform.eulerAngles = desiredRotation;
        transform.Translate(Input.GetAxis("Horizontal") * 0.75f, 0, Input.GetAxis("Vertical") * 0.75f);
	}
}
 