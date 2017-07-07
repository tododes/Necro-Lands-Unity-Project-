using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyRewardPanel : AreYouSurePanel {

    public new static DailyRewardPanel singleton;

    new void Awake(){
        singleton = this;
    }
}
