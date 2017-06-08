using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UltimateGameMode : GameMode {

    private UltimateMission ultimateMission;

    public override void Save(){
        Clock clock = new Clock(5, 0);
        ultimateMission = new UltimateMission("Ez ultimate", "Catch the chicken", 5, clock, true, false, true, 2, 3);
        SaveMission<UltimateMission>(ultimateMission, "/MissionData.data");
    }
}
