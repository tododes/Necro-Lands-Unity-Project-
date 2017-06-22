using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SkillDatabase {

    [SerializeField] private List<string> skillNames;
    [SerializeField] private List<Skill> skills;

    public SkillDatabase(){
        skillNames = new List<string>();
        skills = new List<Skill>();
    }

    public Skill getSkillByName(string n){
        return skills[skillNames.IndexOf(n)];
    }

    public string getNameOfSkill(Skill sk){
        return skillNames[skills.IndexOf(sk)];
    }

    public List<Skill> getSkillsByNames(string[] nn){
        List<Skill> ss = new List<Skill>();
        foreach(string n in nn){
            ss.Add(getSkillByName(n));
        }
        return ss;
    }
}
