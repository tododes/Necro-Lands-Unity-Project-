using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : TodoBehaviour {

    private RectTransform rect;
    private Vector3 translateRate, desiredPosition;

    void Start(){
        rect = Cp<RectTransform>();
        translateRate = new Vector3(700, 0, 0);
        desiredPosition = new Vector3(-350, rect.localPosition.y, rect.localPosition.z);
    }

	void Update () {
        if (rect.localPosition.x < -350f)
            rect.localPosition += translateRate * Time.deltaTime;
        else if (rect.localPosition.x > -350f)
            rect.localPosition = desiredPosition;
        //Debug.Log(rect.localPosition);
    }
}
