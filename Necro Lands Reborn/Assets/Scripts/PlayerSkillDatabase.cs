using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[System.Serializable]
public class PlayerSkillDatabase {

    [SerializeField] private List<string> playerName = new List<string>();
    [SerializeField] private List<SkillArrayList> playerSkills = new List<SkillArrayList>();

    private BinaryFormatter bf;
    private SkillDatabase skillDB;

    public PlayerSkillDatabase(BinaryFormatter b){
        bf = b;
        skillDB = new SkillDatabase();
    }

    public Skill[] getSkillsOf(string name){
        SkillArrayList sal = playerSkills[playerName.IndexOf(name)];
        List<Skill> skills = skillDB.getSkillsByNames(sal.ToArray());
        return skills.ToArray();
    }
}

[System.Serializable]
public class SkillArrayList {

    [SerializeField] private List<string> skillNames = new List<string>();

    public void Add(string st) { skillNames.Add(st); }
    public string get(int i) { return skillNames[i]; }
    public void set(int i, string s) { skillNames[i] = s; }
    public string[] ToArray() { return skillNames.ToArray(); }
}
