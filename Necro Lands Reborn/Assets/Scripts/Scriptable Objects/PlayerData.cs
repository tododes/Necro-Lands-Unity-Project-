using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData{
    public int TotalMoney;
    public string Name;

    public int Level;
    public int Exp;
    public int Token;

    private List<string> skillNames = new List<string>();

    public void AddSkillName(string name){
        skillNames.Add(name);
    }
}
