using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageImage : Image {

    private Color colorFadeRate;
    private Color triggerColor;

    new void Start(){
        base.Start();
        colorFadeRate = new Color(0, 0, 0, -1.5f);
        triggerColor = new Color(1, 0, 0, 0);
    }

    void Update(){
        if (color.a > 0f){
            color += colorFadeRate * Time.deltaTime;
        }
    }

    public void Trigger(float alpha){
        triggerColor.a = alpha;
        color = triggerColor;
    }
}
