using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionFailedPanel : AreYouSurePanel {

    [SerializeField] private Image image;

    new void Start(){
        base.Start();
    }

    protected override void Update(){
        if (Index == 0 && rect.localScale.x > 0){
            rect.localScale = rect.localScale - IncrementFactor * Time.deltaTime;
        }
        else if (Index == 0 && rect.localScale.x <= 0){
            rect.localScale = zeroVector;
            image.enabled = false;
        }

        if (Index == 1 && rect.localScale.x < desiredSize){
            if(!image.enabled)
                image.enabled = true;
            rect.localScale = rect.localScale + IncrementFactor * Time.deltaTime;
        }

    }
}
