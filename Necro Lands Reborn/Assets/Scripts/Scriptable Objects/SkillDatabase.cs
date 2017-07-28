using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDatabase : ScriptableObject {

    [SerializeField] private List<string> skillNames = new List<string>();
    [SerializeField] private List<Skill> skills = new List<Skill>();
    [SerializeField] private List<Sprite> skillSprites = new List<Sprite>();

    public Sprite getSkillSprite(Skill skill){
        return skillSprites[skills.IndexOf(skill)];
    }

    public Skill getSkillByName(string Name){
        Debug.Log("Index : " + skillNames.IndexOf(Name));
        return skills[skillNames.IndexOf(Name)];
    }

    public string getSkillName(Skill skill) {
        return skillNames[skills.IndexOf(skill)];
    }
}
