using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalentDatabase : ScriptableObject {

    [SerializeField]
    private List<PlayerTalentList> playerTalentListCollection = new List<PlayerTalentList>();

    public void setTalentList(List<PlayerTalentList> ptl) { playerTalentListCollection = ptl; }
    public PlayerTalentList getTalentList(int i) { return playerTalentListCollection[i]; }
}
