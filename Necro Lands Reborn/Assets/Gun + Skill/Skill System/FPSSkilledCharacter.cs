using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FPSSkilledCharacter : FPSCharacter
{
    [SerializeField]
    List<Skill> skills = new List<Skill>();
    List<KeyCode> keys = new List<KeyCode>();

    SkillSprite[] sprites;

    void Start()
    {
        sprites = FindObjectsOfType<SkillSprite>();
        for (int i = 0; i < skills.Count; i++)
        {
            keys[i] = KeyCode.Alpha1 + i;
            sprites[i].SetKeyCode(keys[i]);
            sprites[i].SetSkill(skills[i]);
        }
    }

    void Update()
    {

    }
}
