using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MissionDatabase {
    [SerializeField] private List<Mission> missions;
    [SerializeField] private List<bool> missionsAccomplishment;
    [SerializeField] private List<bool> missionsUnlockStatus;

    public MissionDatabase(){
        missions = new List<Mission>();
        missionsAccomplishment = new List<bool>();
        missionsUnlockStatus = new List<bool>();
    }

    public void MissionAccomplished(Mission mission){
        if (!missions.Contains(mission)){
            missions.Add(mission);
            missionsAccomplishment.Add(true);
        }
        else{
            missionsAccomplishment[missions.IndexOf(mission)] = true;
        }
    }

    public void UnlockMission(Mission mission)
    {
        if (!missions.Contains(mission)){
            missions.Add(mission);
            missionsUnlockStatus.Add(true);
        }
        else{
            missionsUnlockStatus[missions.IndexOf(mission)] = true;
        }
    }

    public int getIndexOf(Mission mission){
        return missions.IndexOf(mission);
    }

    public bool isMissionUnlocked(Mission mission){
        int i = missions.IndexOf(mission);
        return missionsUnlockStatus[i];
    }
}
