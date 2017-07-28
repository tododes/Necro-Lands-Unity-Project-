using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Magic {

	void Update () {
        transform.Translate(Vector3.down * 30f * Time.deltaTime);
	}
}
