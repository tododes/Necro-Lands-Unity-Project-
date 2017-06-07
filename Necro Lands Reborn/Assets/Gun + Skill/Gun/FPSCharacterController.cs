using UnityEngine;
using System.Collections;

public class FPSCharacterController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * Time.deltaTime * 270f, 0));
        transform.Translate(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	}
}
 