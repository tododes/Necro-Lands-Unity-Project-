using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionAccomplishedPanel : AreYouSurePanel {

    public new static MissionAccomplishedPanel singleton;


    new void Awake(){
        singleton = this;
    }

    protected override void Update(){
        base.Update();
        //if (Index == 1 && rect.localScale.x >= desiredSize){
        //    if(Index == 1){
        //        Time.timeScale = 0;
        //        Index = 5;
        //    }
            
        //}
    }

    public void UnpauseAndGoToNextMission() { Time.timeScale = 1f; }
}
