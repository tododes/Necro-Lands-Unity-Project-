using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : TodoBehaviour {

    [SerializeField] private RectTransform rect;

    protected Vector2 desiredSize;
	protected virtual void Start () {
        rect = Cp<RectTransform>();
        desiredSize = new Vector2(0, 30);
	}

    protected virtual void Update () {
        rect.sizeDelta = desiredSize;
	}
}
