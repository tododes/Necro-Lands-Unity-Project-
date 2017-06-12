using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SkillSprite : MonoBehaviour {

    private KeyCode key;
    private Image image;

    [SerializeField]
    private Skill skill;

    public void SetSkill(Skill s)
    {
        skill = s;
    }

    public void SetKeyCode(KeyCode k)
    {
        key = k;
    }
	
	void Start ()
    {
        image = GetComponent<Image>();
    }
	
	void Update ()
    {
	    if(skill)
        {
            if(Input.GetKeyDown(key) && skill.Ready()){
                skill.Use();
            }
            image.sprite = skill.sprite;
        }
	}
}
